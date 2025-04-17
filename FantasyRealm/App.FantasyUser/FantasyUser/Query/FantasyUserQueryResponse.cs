using Core.App.Features;


namespace App.FantasyUser.FantasyUser.Query
{
    public class FantasyUserQueryResponse: QueryResponse
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfilePicturePath { get; set; }
    }
}
