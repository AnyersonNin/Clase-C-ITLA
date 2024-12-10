using BoletoBusApp.Data.Entities.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BoletoBusApp.Data.Context
{
    public partial class BoletoContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Conductor> Conductors { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Status> Status { get; set; }

    }
}
