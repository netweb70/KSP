using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Prestamo")]
    public partial class Prestamo
    {
        public Prestamo()
        {
            DetallePrestamo = new HashSet<DetallePrestamo>();
        }

        [Key, Required]
        public int IdPrestamo { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public int? IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }

        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; set; }
    }
}
