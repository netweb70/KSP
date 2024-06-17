using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("DetallePrestamo")]
    public partial class DetallePrestamo
   {
        [Key, Required]
        public int IdDetallePrestamo { get; set; }
        public int? IdPrestamo { get; set; }
        public int? IdLibro { get; set; }
        public int? Cantidad { get; set; }
        public int? Devuelta { get; set; }

        public virtual Libro? IdLibroNavigation { get; set; }
        public virtual Prestamo? IdPrestamoNavigation { get; set; }
   }
}
