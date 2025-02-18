
using Core.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm
{
    public class Personality: Entity 
    {
        [Required, StringLength(125)]
        public string Name { get; set; }
    }
}
