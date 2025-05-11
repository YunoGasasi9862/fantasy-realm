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

        public int RoleId { get; set; }

        public virtual FantasyUserRole Role { get; set; }

        public virtual FantasyUserRefreshToken FantasyUserRefreshToken { get; set; }

        public override string ToString()
        {
            return $"FantasyUser: Id = {Id}, Name = {Name} {Surname}, Username = {Username}, Email = {Email}, " +
                   $"DOB = {DateOfBirth:yyyy-MM-dd}, IsActive = {IsActive}, Role = {Role.ToString()}";
        }
    }
}
