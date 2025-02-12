
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Domain
{
    public class FantasyRealmDBContext: DbContext
    {
        DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=FantasyRealmDB;trusted_connection=true;"));
        }
    }
}
