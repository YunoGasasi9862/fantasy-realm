using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.FantasyUser.Update
{
    public class FantasyUserUpdateRequest: CommandRequest, IRequest<CommandResponse>
    {
        //remove add properties if you want to, but for now adding the same ones
        public FantasyUserUpdateRequest() { }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfilePicturePath { get; set; }

        public static Domain.FantasyUser Copy(FantasyUserUpdateRequest fantasyUserUpdateRequest, Domain.FantasyUser fantasyUser)
        {
            fantasyUser.Name = fantasyUserUpdateRequest.Name.Trim();
            fantasyUser.Surname = fantasyUserUpdateRequest.Surname.Trim();
            fantasyUser.Username = fantasyUserUpdateRequest.Username.Trim();
            fantasyUser.Email = fantasyUserUpdateRequest.Email.Trim();
            fantasyUser.Password = fantasyUserUpdateRequest.Password.Trim();
            fantasyUser.DateOfBirth = fantasyUserUpdateRequest.DateOfBirth;
            fantasyUser.ProfilePicturePath = fantasyUserUpdateRequest.ProfilePicturePath.Trim();
            fantasyUser.Id = fantasyUserUpdateRequest.Id;

            return fantasyUser;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Username: {Username}, Email: {Email}, Password: {Password}, DateOfBirth: {DateOfBirth}, profilePicture: {ProfilePicturePath},";
        }
    }
}
