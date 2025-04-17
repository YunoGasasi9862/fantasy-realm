using Core.App.Domain;

namespace App.FantasyRealm.Domain
{
    //many to many
    public class FantasyUserPersonalityAssociation: Entity
    {
        public int FantasyUserId { get; set; }

        public int PersonalityTypeId { get; set;}

        //fix this
       // public virtual FantasyUser FantasyUser { get; set; }

        public virtual PersonalityType PersonalityType { get; set;}
    }
}
