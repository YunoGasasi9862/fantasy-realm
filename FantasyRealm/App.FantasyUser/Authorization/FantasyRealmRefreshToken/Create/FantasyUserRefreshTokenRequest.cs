using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
    }
}
