using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class Context : DbContext
    {    
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<TeamsCompetitions> TeamsCompetitions { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<TeamsCompetitions>().HasKey(tc => new { tc.TeamId, tc.CompetitionId });

            // One to many for m-m
            modelBuilder.Entity<TeamsCompetitions>()
                        .HasOne(tc => tc.Team)
                        .WithMany(tc => tc.TeamsCompetitions)
                        .HasForeignKey(tc => tc.TeamId);

            modelBuilder.Entity<TeamsCompetitions>()
                        .HasOne(tc => tc.Competition)
                        .WithMany(tc => tc.TeamsCompetitions)
                        .HasForeignKey(tc => tc.CompetitionId);


            // One to one
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Stadium)
                .WithOne(s => s.Team)
                .HasForeignKey<Stadium>(s => s.TeamId);

            // One to many
            modelBuilder.Entity<Team>()
                        .HasMany(t => t.Players)
                        .WithOne(p => p.Team)
                        .HasForeignKey(p =>  p.TeamId);
                   

            base.OnModelCreating(modelBuilder);
        }

    }
}
