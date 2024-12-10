using BoletoBusApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Entities.Reservation
{
    [Table("ConductorBus")]
    public sealed class ConductorBus : AuditEntity<int>
    {
        [Key]
        [Column("ConductorBusID")]
        public override int Id { get; set; }
        public int ConductorID { get; set; }
        public int BusId { get; set; }
        public DateTime FechaAsignacion {  get; set; }
    }
}
