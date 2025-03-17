using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUser.Create
{
    public class FantasyUserCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserCreateRequest() { }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        //path
        public string profilePicture { get; set; }
    }
}
