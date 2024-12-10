using BoletoBusApp.Data.Base;
using BoletoBusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Entities.Reservation
{
    [Table("Viaje")]
    public sealed class Viaje : AuditEntity<int>
    {
        [Key]
        [Column("IdViaje")]
        public override int Id { get; set; }
        public int IdBus { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateOnly HoraSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateOnly HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public int TotalAsientos { get; set; }
        public int AsientosRervados { get; set; }
        public int AsientoDisponibles { get; set; }
        public int Completo {  get; set; }


    }
}
