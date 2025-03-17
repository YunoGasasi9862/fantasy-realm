using Core.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.Domain
{
    public class PersonalityType: Entity
    {
        [Required, StringLength(125)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
