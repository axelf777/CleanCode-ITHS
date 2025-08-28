using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanCode
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
