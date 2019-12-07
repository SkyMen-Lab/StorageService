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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Game model setup

            modelBuilder.Entity<Game>()
                .HasIndex(g => g.Code)
                .IsUnique();
            modelBuilder.Entity<Game>()
                .HasMany(g => g.TeamGameSummaries)
                .WithOne(ts => ts.Game)
                .HasForeignKey(ts => ts.GameId);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Winner)
                .WithMany(w => w.GamesWon)
                .HasForeignKey(g => g.WinnerId);

            #endregion

            #region Team models setup

            modelBuilder.Entity<Team>()
                .HasIndex(t => t.Code)
                .IsUnique();
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Configs)
                .WithOne(c => c.Team)
                .HasForeignKey<Config>(c => c.TeamId);

            #endregion

            #region Configs model setup

            modelBuilder.Entity<Config>()
                .HasIndex(c => c.RouterIpAddress);
            modelBuilder.Entity<Config>()
                .HasIndex(c => c.RouterPort);
            modelBuilder.Entity<Config>()
                .HasOne(c => c.Team)
                .WithOne(t => t.Configs)
                .HasForeignKey<Team>(t => t.ConfigId);

            #endregion

            #region TeamGameSummary

            modelBuilder.Entity<TeamGameSummary>()
                .HasOne(ts => ts.Team)
                .WithMany(t => t.TeamGameSummaries)
                .HasForeignKey(ts => ts.TeamId);
            modelBuilder.Entity<TeamGameSummary>()
                .Property(ts => ts.IsWinner)
                .HasDefaultValue(false);
            modelBuilder.Entity<TeamGameSummary>()
                .Property(ts => ts.Score)
                .HasDefaultValue(0);

            #endregion
        }
    }
}