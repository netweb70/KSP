using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("NumeroDocumento")]
    public partial class NumeroDocumento
    {
        public int Id { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
