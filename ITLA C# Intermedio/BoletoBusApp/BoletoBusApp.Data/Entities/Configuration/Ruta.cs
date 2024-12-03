using BoletoBusApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Entities.Configuration
{
    [Table("Ruta", Schema = "Configuration")]
    public sealed class Ruta : AuditEntity<int>
    {
        [Key]
        [Column("IdRuta")]
        public override int Id { get; set; }

        public int IdRuta { get; set; }

        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool Estatus { get; set; }

    }
}
