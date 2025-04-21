using Microsoft.EntityFrameworkCore;

namespace App.FantasyUser.Domain
{
    public class FantasyUserDbContext: DbContext
    {
        public DbSet<FantasyUser> FantasyUsers { get; set; }

        public DbSet<FantasyUserRefreshToken> RefreshTokens { get; set; }

        public FantasyUserDbContext(DbContextOptions<FantasyUserDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        
        }
    }
}
