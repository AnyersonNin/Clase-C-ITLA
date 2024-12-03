using BoletoBusApp.Data.Entities.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Context
{
    public partial class BoletoContext : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaDetalle> ReservasDetalle { get; set; }
        public DbSet<Viaje> Viaje { get; set; }
    }
}
