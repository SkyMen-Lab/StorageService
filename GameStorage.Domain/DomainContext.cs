using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain
{
    public class DomainContext : DbContext
    {
        public DbSet<Config> Configs { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamGameSummary> TeamGameSummaries { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //temporary solution for db
            // Will be replaced by PostgreSQL in future
            optionsBuilder.UseSqlite("Data Source=dev.db");
        }
    }
}