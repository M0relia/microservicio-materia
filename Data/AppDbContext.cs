using Microsoft.EntityFrameworkCore;
using MicroservicioMateria.Models;

namespace MicroservicioMateria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Materia> Materias { get; set; }
    }
}
