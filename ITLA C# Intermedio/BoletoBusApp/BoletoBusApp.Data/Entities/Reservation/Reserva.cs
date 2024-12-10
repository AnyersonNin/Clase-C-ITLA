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
    [Table("Reserva")]
    public sealed class Reserva : AuditEntity<int>
    {
        [Key]
        [Column("IdReserva")]
        public override int Id { get; set; }
        public int IdViaje { get; set; }
        public int IdPasajero { get; set; }
        public int AsientosReservados {  get; set; }
        public decimal MontoTotal { get; set; }
    }
}
