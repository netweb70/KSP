using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.DTO;
using System.Data;
using System.Globalization;
using System.Xml.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly DB_Context _context;
        public PrestamoController(DB_Context context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("Libros/{busqueda}")]
        public async Task<IActionResult> Libros(string busqueda)
        {
            List<DtoLibro> lista = new List<DtoLibro>();
            try
            {
                lista = await _context.Libros
                .Where(p => string.Concat(p.Codigo.ToLower(), p.Editorial.ToLower(), p.Descripcion.ToLower()).Contains(busqueda.ToLower()))
                .Select(p => new DtoLibro()
                {
                    IdLibro = p.IdLibro,
                    Codigo = p.Codigo,
                    Editorial = p.Editorial,
                    Descripcion = p.Descripcion,
                }).ToListAsync();


                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar([FromBody] DtoPrestamo request)
        {
            try
            {
                string numeroDocumento = "";

                XElement libro = new XElement("Libros");
                foreach (DtoLibro item in request.listaLibros)
                {
                    libro.Add(new XElement("Item",
                        new XElement("IdLibro", item.IdLibro),
                        new XElement("Cantidad", item.Cantidad)
                        ));
                }

                using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarPrestamo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("documentoCliente", SqlDbType.VarChar, 40).Value = request.documentoCliente;
                    cmd.Parameters.Add("nombreCliente", SqlDbType.VarChar, 40).Value = request.nombreCliente;
                    cmd.Parameters.Add("tipoDocumento", SqlDbType.VarChar, 50).Value = request.tipoDocumento;
                    cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = request.idUsuario;
                    cmd.Parameters.Add("libro", SqlDbType.Xml).Value = libro.ToString();
                    cmd.Parameters.Add("nroDocumento", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    numeroDocumento = cmd.Parameters["nroDocumento"].Value.ToString();
                }

                return StatusCode(StatusCodes.Status200OK, new { numeroDocumento = numeroDocumento });
            }
            catch (Exception ex)
            {

                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new { numeroDocumento = "" });
            }
        }

        [HttpPost]
        [Route("RegistrarDevolucion")]
        public IActionResult RegistrarDevolucion([FromBody] DtoDevolucion request)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegistrarDevolucion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IdDetallePrestamo", SqlDbType.Int).Value = request.IdDetallePrestamo;
                    cmd.Parameters.Add("Devuelta", SqlDbType.Int).Value = request.Devuelta;
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {

                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            string buscarPor = HttpContext.Request.Query["buscarPor"];
            string numeroPrestamo = HttpContext.Request.Query["numeroPrestamo"];
            string fechaInicio = HttpContext.Request.Query["fechaInicio"];
            string fechaFin = HttpContext.Request.Query["fechaFin"];

            DateTime _fechainicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));
            DateTime _fechafin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"));

            List<DtoHistorialPrestamo> lista_prestamo = new List<DtoHistorialPrestamo>();
            try
            {
                if (buscarPor == "fecha")
                {
                    lista_prestamo = await _context.Prestamo
                        .Include(u => u.IdUsuarioNavigation)
                        .Include(d => d.DetallePrestamo)
                        .ThenInclude(p => p.IdLibroNavigation)
                        .Where(v => v.FechaRegistro.Value.Date >= _fechainicio.Date && v.FechaRegistro.Value.Date <= _fechafin.Date)
                        .Select(v => new DtoHistorialPrestamo()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            NumeroDocumento = v.NumeroDocumento,
                            TipoDocumento = v.TipoDocumento,
                            DocumentoCliente = v.DocumentoCliente,
                            NombreCliente = v.NombreCliente,
                            UsuarioRegistro = v.IdUsuarioNavigation.Nombre,
                            Detalle = v.DetallePrestamo.Select(d => new DtoDetallePrestamo()
                            {
                                Libro = d.IdLibroNavigation.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                                Devuelta = d.Devuelta.ToString(),
                                IdDetallePrestamo = d.IdDetallePrestamo
                            }).ToList()
                        })
                        .ToListAsync();
                }
                else
                {
                    lista_prestamo = await _context.Prestamo
                        .Include(u => u.IdUsuarioNavigation)
                        .Include(d => d.DetallePrestamo)
                        .ThenInclude(p => p.IdLibroNavigation)
                        .Where(v => v.NumeroDocumento == numeroPrestamo)
                        .Select(v => new DtoHistorialPrestamo()
                        {
                            FechaRegistro = v.FechaRegistro.Value.ToString("dd/MM/yyyy"),
                            NumeroDocumento = v.NumeroDocumento,
                            TipoDocumento = v.TipoDocumento,
                            DocumentoCliente = v.DocumentoCliente,
                            NombreCliente = v.NombreCliente,
                            UsuarioRegistro = v.IdUsuarioNavigation.Nombre,
                            Detalle = v.DetallePrestamo.Select(d => new DtoDetallePrestamo()
                            {
                                Libro = d.IdLibroNavigation.Descripcion,
                                Cantidad = d.Cantidad.ToString(),
                            }).ToList()
                        }).ToListAsync();
                }


                return StatusCode(StatusCodes.Status200OK, lista_prestamo);
            }
            catch (Exception ex)
            {
                var str = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, lista_prestamo);
            }


        }


    }
}
