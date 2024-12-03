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
    [Table("Conductor", Schema = "Configuration")]
    public sealed class Conductor : AuditEntity<int>
    {
        [Key]
        [Column("ConductorID")]
        public override int Id { get; set; }
        public int ConductorId { get; set;}
        public string Telefono { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime FechaContratacion {  get; set; }
        public bool Estatus {  get; set; }

    }
}
