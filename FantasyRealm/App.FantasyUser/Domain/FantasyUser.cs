using Core.App.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.FantasyUser.Domain
{
    public class FantasyUser: Entity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public string ProfilePicturePath { get; set; }

        [JsonIgnore] 
        public virtual FantasyUserRole Role { get; set; }

        [JsonIgnore]
        public virtual FantasyUserRefreshToken FantasyUserRefreshToken { get; set; }
    }
}
