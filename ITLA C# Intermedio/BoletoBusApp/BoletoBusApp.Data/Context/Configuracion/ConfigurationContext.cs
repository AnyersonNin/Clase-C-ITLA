using BoletoBusApp.Data.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBusApp.Data.Context.Configuracion
{
    public partial class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
        {
            
        }

        #region "DbSets"

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Conductor> Conductors { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<Status> Status { get; set; }

        #endregion

    }
}
