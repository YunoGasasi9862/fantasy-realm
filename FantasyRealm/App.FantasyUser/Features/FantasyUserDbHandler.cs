using App.FantasyUser.Domain;
using Core.App.Features;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace App.FantasyUser.Features
{
    public class FantasyUserDbHandler: Handler, IDBHandler
    {
        protected FantasyUserDbContext FantasyUserDbContext { get; private set; }

        protected AccessTokenSettings FantasyTokenSettings { get; set; }

        public FantasyUserDbHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(new CultureInfo("en-US"))
        {
            FantasyUserDbContext = fantasyUserDbContext;

            FantasyTokenSettings = accessTokenSettings.Value;

            Debug.WriteLine($"Original Token Settings: {FantasyTokenSettings.ToString()}");
        }

        protected virtual string CreateAccessToken(List<Claim> claims, DateTime accessTokenExpiration)
        {
            SigningCredentials signingCredentials = new SigningCredentials(FantasyTokenSettings.SigningKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(FantasyTokenSettings.Issuer, FantasyTokenSettings.Audience, claims, DateTime.Now, accessTokenExpiration, signingCredentials);

            Debug.WriteLine($"signingCredentials: {signingCredentials}");

            Debug.WriteLine($"jwtSecurityToken: {jwtSecurityToken}");

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        protected virtual List<Claim> GetClaims(Domain.FantasyUser fantasyUser)
        {
            Debug.WriteLine(fantasyUser.ToString());
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, fantasyUser.Name),
                new Claim(ClaimTypes.Role, fantasyUser.Role.Name),
                new Claim("Id", fantasyUser.Id.ToString())
            };

        }

        protected virtual ClaimsPrincipal? GetClaimsPrincipal(string accessToken)
        {
            //removes the bearer part if it exists
            accessToken = accessToken.StartsWith(JwtBearerDefaults.AuthenticationScheme) ? 
                accessToken.Remove(0, JwtBearerDefaults.AuthenticationScheme.Length + 1) : accessToken;

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = FantasyTokenSettings.SigningKey
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken? securityToken = null;

            ClaimsPrincipal principal = jwtSecurityTokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            return securityToken == null ? null : principal;
        }
    }
}
