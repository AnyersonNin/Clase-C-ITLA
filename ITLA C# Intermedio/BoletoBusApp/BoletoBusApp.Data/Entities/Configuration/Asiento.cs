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
    [Table("Asiento", Schema = "Configuration")]
    public sealed class Asiento : AuditEntity<int>
    {
        [Key]
        [Column("IdAsiento")]
        public override int Id { get; set; }

        public int IdAsiento { get; set; }
        public int IdBus { get; set; }
        public short NumeroPiso { get; set; }
        public short NumeroAsiento { get; set; }
        public bool Estatus { get; set; }
                     

    }
}
