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
        public DbSet<Szobak> Szoba { get; set; }
        public DbSet<Vendegek> Vendeg { get; set; }
    }
}
