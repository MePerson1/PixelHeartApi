using Microsoft.EntityFrameworkCore;
using PixelHeartApi.Models;

namespace PixelHeartApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Match>()
                        .HasOne(p => p.Love)
                        .WithMany()
                        .HasForeignKey(p => p.LoveId)
                        .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
