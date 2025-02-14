
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Domain
{
    public class FantasyRealmDBContext: DbContext
    {
        DbSet<Personality> Tags { get; set; }

        public FantasyRealmDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
