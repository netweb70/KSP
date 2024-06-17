namespace API.Models.DTO
{
    public class DtoHistorialPrestamo
    {
        public string? FechaRegistro { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? UsuarioRegistro { get; set; }

        public List<DtoDetallePrestamo> Detalle { get; set; }


    }
}
