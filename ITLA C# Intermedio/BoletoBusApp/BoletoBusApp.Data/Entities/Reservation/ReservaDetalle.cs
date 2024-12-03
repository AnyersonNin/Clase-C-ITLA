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

    [Table("ReservaDetalle")]
    public sealed class ReservaDetalle : AuditEntity<int>
    {
        [Key]
        [Column("ReservaDetalle")]
        public override int Id { get; set; }
        public int IdReservaDetalle { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }
    }
}
