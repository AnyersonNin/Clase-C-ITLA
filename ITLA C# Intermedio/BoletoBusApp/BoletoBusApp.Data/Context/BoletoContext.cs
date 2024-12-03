using BoletoBusApp.Data.Entities.Configuration;
using BoletoBusApp.Data.Entities.Reservation;
using BoletoBusApp.Data.Entities.Security;
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
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options) 
        {
            
        }
        #region "DbSets"
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

    }
}
