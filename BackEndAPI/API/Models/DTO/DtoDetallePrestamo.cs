namespace API.Models.DTO
{
    public class DtoDetallePrestamo
    {
        public int IdDetallePrestamo { get; set; }
        public string? Libro { get; set; }

        public string? Cantidad { get; set; }
        public string? Devuelta { get; set; }

   }
}
