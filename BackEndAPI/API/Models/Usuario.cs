using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Prestamo = new HashSet<Prestamo>();
        }

        [Key, Required]
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public string? Clave { get; set; }
        public bool? EsActivo { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
