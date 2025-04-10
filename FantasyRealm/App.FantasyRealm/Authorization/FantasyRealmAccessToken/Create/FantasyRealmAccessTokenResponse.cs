using Core.App.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyRealmAccessTokenResponse: CommandResponse
    {
        public String Token { get; set; }
    }
}
