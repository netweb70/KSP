using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Libro")]
    public partial class Libro
    {
        public Libro()
        {
            DetallePrestamo = new HashSet<DetallePrestamo>();
        }

        [Key, Required]
        public int IdLibro { get; set; }
        public string? Codigo { get; set; }
        public string? Editorial { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; set; }
    }
}
