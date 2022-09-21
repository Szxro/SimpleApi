using SimpleApi.Models;

namespace SimpleApi.Data
{
    public class HeroeContext : DbContext
    {
        public HeroeContext(DbContextOptions<HeroeContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().ToTable("Heroe");
        }
    }
}
