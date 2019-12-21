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

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region GameRepository model setup

            modelBuilder.Entity<Game>()
                .HasIndex(g => g.Code)
                .IsUnique();
            modelBuilder.Entity<Game>()
                .HasMany(g => g.TeamGameSummaries)
                .WithOne(ts => ts.Game)
                .HasForeignKey(ts => ts.GameId);

            #endregion

            #region Team models setup

            modelBuilder.Entity<Team>()
                .HasIndex(t => t.Code)
                .IsUnique();

            #endregion

            #region Configs model setup

            modelBuilder.Entity<Config>()
                .HasIndex(c => c.RouterIpAddress);
            modelBuilder.Entity<Config>()
                .HasIndex(c => c.RouterPort);
            modelBuilder.Entity<Config>()
                .HasOne(c => c.Team)
                .WithOne(t => t.Config)
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