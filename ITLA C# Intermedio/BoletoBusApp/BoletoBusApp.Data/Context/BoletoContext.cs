
using Microsoft.EntityFrameworkCore;

namespace BoletoBusApp.Data.Context
{
    public partial class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options) 
        {
            
        }

    }
}
