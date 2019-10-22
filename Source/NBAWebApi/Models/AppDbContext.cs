using Microsoft.EntityFrameworkCore;

namespace NBAWebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .ToTable("Player");
        }
        
        public DbSet<Player> Players { get; set; }
    }
}