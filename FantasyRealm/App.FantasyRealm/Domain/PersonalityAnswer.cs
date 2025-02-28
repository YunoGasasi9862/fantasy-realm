using Core.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Domain
{
    public class PersonalityAnswer: Entity
    {
        public int PersonalityId { get; set; }

        public int QuestionId { get; set; }

        public int ChoiceId { get; set; }

        public virtual PersonalityType PersonalityType { get; set; }

        public virtual Question Question { get; set; }

        public virtual QuestionChoice Choice { get; set; }  
    }
}
