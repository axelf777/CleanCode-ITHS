using Microsoft.EntityFrameworkCore;

namespace CleanCode.DB
{
    public class PlayerDbContext : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlayerDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
