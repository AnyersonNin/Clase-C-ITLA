using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer
{
    public class GestorTareasContexto : DbContext
    {
        public GestorTareasContexto(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
