using Core.App.Domain;

namespace App.FantasyUser.Domain
{
    public class FantasyUser: Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public string ProfilePicturePath { get; set; }
    }
}
