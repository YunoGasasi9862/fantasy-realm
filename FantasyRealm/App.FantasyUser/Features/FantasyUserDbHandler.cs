using App.FantasyUser.Domain;
using Core.App.Features;
using Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
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

        public FantasyUserDbHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(new CultureInfo("en-US"))
        {
            FantasyUserDbContext = fantasyUserDbContext;

            FantasyTokenSettings = accessTokenSettings;
        }

        protected virtual string CreateAccessToken(List<Claim> claims, DateTime accessTokenExpiration)
        {
            SigningCredentials signingCredentials = new SigningCredentials(FantasyTokenSettings.SigningKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(FantasyTokenSettings.Issuer, FantasyTokenSettings.Audience, claims, DateTime.Now, accessTokenExpiration, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        protected virtual List<Claim> GetClaims(Domain.FantasyUser fantasyUser)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, fantasyUser.Name),
                new Claim(ClaimTypes.Role, fantasyUser.Role.Name),
                new Claim("Id", fantasyUser.Id.ToString())
            };

        }

        protected Task<FantasyUserRefreshToken> GenerateRefreshToken(Domain.FantasyUser fantasyUser)
        {
            byte[] bytes = new byte[FantasyTokenSettings.RefreshTokenLengthInBytes];

            using(RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(bytes);
            }

            return Task.FromResult(new FantasyUserRefreshToken()
            {
                UserId = fantasyUser.Id,
                RefreshToken =  Convert.ToBase64String(bytes),
                RefreshTokenExpirationTime = FantasyTokenSettings.RefreshTokenExpirationTimeInDays
            });
        } 

        protected virtual ClaimsPrincipal GetClaimsPrincipal(string accessToken)
        {
            return null;
        }
    }
}
