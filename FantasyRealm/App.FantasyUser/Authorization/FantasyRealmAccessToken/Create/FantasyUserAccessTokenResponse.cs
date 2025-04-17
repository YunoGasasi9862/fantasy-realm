using Core.App.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenResponse: CommandResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
