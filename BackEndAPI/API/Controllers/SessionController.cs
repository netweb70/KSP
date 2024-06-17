using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.DTO;
//using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly DB_Context _context;
        public SessionController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Dtosesion request)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario = _context.Usuarios.Include(u => u.IdRolNavigation).Where(u => u.Correo == request.correo && u.Clave == request.clave).FirstOrDefault();

                if(usuario == null)
                    usuario = new Usuario();

            return StatusCode(StatusCodes.Status200OK, usuario);
         }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, usuario);
            }
        }
    }
}
