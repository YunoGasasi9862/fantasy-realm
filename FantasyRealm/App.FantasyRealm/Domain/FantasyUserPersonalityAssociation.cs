using Core.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Domain
{
    //many to many
    public class FantasyUserPersonalityAssociation: Entity
    {
        public int FantasyUserId { get; set; }

        public int PersonalityTypeId { get; set;}

        public virtual FantasyUser FantasyUser { get; set; }

        public virtual PersonalityType PersonalityType { get; set;}
    }
}
