using Core.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyUser.Domain
{
    public class FantasyUserRole: Entity
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public List<FantasyUser> FantasyUsers { get; set; } = new List<FantasyUser>();

        public override string ToString()
        {
            return $"FantasyUserRole: Name = {Name}, UsersCount = {FantasyUsers?.Count ?? 0}";
        }
    }
}
