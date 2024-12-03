using BoletoBusApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Entities.Security
{
    [Table("Usuario")]
    public sealed class Usuario : AuditEntity<int>
    {
        [Key]
        [Column("IdUsuario")]
        public override int Id { get; set; }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public char TipoUsuario { get; set; }
        public bool Estatus {  get; set; }
    }
}
