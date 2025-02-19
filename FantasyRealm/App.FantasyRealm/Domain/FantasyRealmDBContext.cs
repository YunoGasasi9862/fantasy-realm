
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Domain
{
    public class FantasyRealmDBContext: DbContext
    {
        public DbSet<PersonalityType> PersonalityTypes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public FantasyRealmDBContext(DbContextOptions<FantasyRealmDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
