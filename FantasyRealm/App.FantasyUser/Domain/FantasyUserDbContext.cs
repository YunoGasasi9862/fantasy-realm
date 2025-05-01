using Microsoft.EntityFrameworkCore;

namespace App.FantasyUser.Domain
{
    public class FantasyUserDbContext: DbContext
    {
        public DbSet<FantasyUser> FantasyUsers { get; set; }

        public DbSet<FantasyUserRefreshToken> RefreshTokens { get; set; }

        public DbSet<FantasyUserRole> FantasyUserRoles { get; set; }

        public FantasyUserDbContext(DbContextOptions<FantasyUserDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FantasyUserRefreshToken>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<FantasyUserRefreshToken>()
                .HasOne(x => x.FantasyUser)
                .WithOne(t => t.FantasyUserRefreshToken)
                .HasForeignKey<FantasyUserRefreshToken>(t => t.UserId);
        }
    }
}
