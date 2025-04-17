using Core.App.Features;
using MediatR;
using System.Text.Json.Serialization;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenRequest: CommandRequest, IRequest<CommandResponse>
    {
        [JsonIgnore]
        public new int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
