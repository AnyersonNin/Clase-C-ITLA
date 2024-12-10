using BoletoBusApp.Data.Entities.Reservation;
using BoletoBusApp.Data.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace BoletoBusApp.Data.Context
{
    public partial class BoletoContext 
    {

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaDetalle> ReservasDetalle { get; set; }
        public DbSet<Viaje> Viaje { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
