using Fogado.Models;
using Microsoft.EntityFrameworkCore;

namespace Fogado.Data
{
    public class FogadoDbContext : DbContext
    {
        public FogadoDbContext(DbContextOptions<FogadoDbContext> options)
            : base(options)
        {

        }

        public DbSet<Foglalasok> Foglalas { get; set; }
    }
}
