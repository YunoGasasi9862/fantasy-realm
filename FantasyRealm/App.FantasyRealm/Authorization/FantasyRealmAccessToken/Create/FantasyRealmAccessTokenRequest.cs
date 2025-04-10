using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.FantasyRealm.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyRealmAccessTokenRequest: CommandRequest, IRequest<CommandResponse>
    {
        [JsonIgnore]
        public new int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


    }
}
