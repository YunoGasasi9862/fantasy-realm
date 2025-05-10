using Core.App.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyUser.Authorization.Common
{
    public class TokenResponse: CommandResponse
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public TokenResponse(bool isSuccessful, string? message, int id = 0) : base(isSuccessful, message, id)
        {

        }
    }
}
