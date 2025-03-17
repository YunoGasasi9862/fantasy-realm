
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Domain
{
    public class FantasyRealmDBContext: DbContext
    {
        public DbSet<PersonalityType> PersonalityTypes { get; set; }

        public DbSet<FantasyUser> FantasyUsers { get; set; }    

        public DbSet<FantasyUserPersonalityAssociation> FantsayUserPersonalityAssociations { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        public DbSet<PersonalityAnswer> PersonalityAnswers { get; set; }

        public FantasyRealmDBContext(DbContextOptions<FantasyRealmDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonalityAnswer>()
                .HasOne(pa => pa.PersonalityType)
                .WithMany()  
                .HasForeignKey(pa => pa.PersonalityTypeId)
                .OnDelete(DeleteBehavior.Restrict); //restricts deletion of a personalityType if its being referenced in PersonalityAnswer

            modelBuilder.Entity<PersonalityAnswer>()
                .HasOne(pa => pa.Question)
                .WithMany() 
                .HasForeignKey(pa => pa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); //restricts deletion of a Question if its being referenced in PersonalityAnswer

            modelBuilder.Entity<PersonalityAnswer>()
                .HasOne(pa => pa.Choice)
                .WithMany() 
                .HasForeignKey(pa => pa.ChoiceId)
                .OnDelete(DeleteBehavior.Restrict); ///restricts deletion of a choice if its being referenced in PersonalityAnswer

            modelBuilder.Entity<QuestionChoice>()
                .HasOne(q => q.Question)
                .WithMany()
                .HasForeignKey(qc => qc.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); //restricts deletion of a Question if its being referenced in QuestionChoice
        }
    }
}
