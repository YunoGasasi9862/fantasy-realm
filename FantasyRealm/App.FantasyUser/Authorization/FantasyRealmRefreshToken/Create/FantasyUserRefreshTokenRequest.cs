using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create
{
    public class FantasyUserRefreshTokenRequest : CommandRequest, IRequest<FantasyUserRefreshTokenResponse>
    {
        [JsonIgnore]
        public new int Id { get; set; }

        [Required]
        public string AccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        public override string ToString()
        {
            return $"TokenRequest: AccessToken = {AccessToken}, RefreshToken = {RefreshToken}";
        }
    }
}
