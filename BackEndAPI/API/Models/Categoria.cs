using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Categoria") ]
    public partial class Categoria
    {
        public Categoria()
        {
            Libros = new HashSet<Libro>();
        }

        [Key, Required]
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
    