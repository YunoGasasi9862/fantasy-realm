using Core.App.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.PersonalityType.Query
{
    public class PersonalityTypeQueryResponse : QueryResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
