namespace API.Models.DTO
{
    public class DtoPrestamo
    {
        public string documentoCliente { get; set; }
        public string nombreCliente { get; set; }
        public string tipoDocumento { get; set; }
        public int idUsuario { get; set; }

        public List<DtoLibro> listaLibros { get; set; }
    }
}
