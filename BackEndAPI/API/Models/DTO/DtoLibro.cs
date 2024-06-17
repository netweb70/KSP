namespace API.Models.DTO
{
    public class DtoLibro
    {
        public int IdLibro { get; set; }
        public string? Codigo { get; set; }
        public string? Editorial { get; set; }
        public string? Descripcion { get; set; }

        public int Cantidad { get; set; }

    }
}
