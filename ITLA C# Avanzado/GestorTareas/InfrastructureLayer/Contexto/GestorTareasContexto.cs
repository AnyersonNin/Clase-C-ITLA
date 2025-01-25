using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.Contexto
{
    public class GestorTareasContexto : DbContext
    {
        public GestorTareasContexto(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
