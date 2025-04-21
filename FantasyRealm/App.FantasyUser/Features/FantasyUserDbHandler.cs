using App.FantasyUser.Domain;
using Core.App.Features;
using Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Security.Claims;

namespace App.FantasyUser.Features
{
    public class FantasyUserDbHandler: Handler, IDBHandler
    {
        protected FantasyUserDbContext FantasyUserDbContext { get; private set; }

        protected AccessTokenSettings FantasyTokenSettings { get; set; }

        public FantasyUserDbHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(new CultureInfo("en-US"))
        {
            FantasyUserDbContext = fantasyUserDbContext;

            FantasyTokenSettings = accessTokenSettings;
        }

        protected virtual string CreateAccessToken(List<Claim> claims, DateTime accessTokenExpiration)
        {
            var signingCredentials = new SigningCredentials(FantasyTokenSettings.SigningKey, SecurityAlgorithms.HmacSha256Signature);

            return "";
        }


        protected Task<FantasyUserRefreshToken> GenerateRefreshToken()
        {
            return null;
        } 
    }
}
