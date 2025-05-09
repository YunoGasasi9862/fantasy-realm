using App.FantasyUser.Authorization.Common;
using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenRequest: CommandRequest, IRequest<FantasyUserAccessTokenResponse>
    {
        [JsonIgnore]
        public new int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
