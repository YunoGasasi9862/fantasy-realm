using Core.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Domain
{
    public class QuestionChoice: Entity
    {
        public int QuestionId { get; set; }

        public string Choice { get; set; }

        public virtual Question Question { get; set; }
    }
}
