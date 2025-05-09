using App.FantasyUser.Domain;
using Core.App.Features;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        protected async Task<FantasyUserRefreshToken> CreateFantasyUserRefreshToken(Domain.FantasyUser fantasyUser)
        {
            byte[] bytes = new byte[FantasyTokenSettings.RefreshTokenLengthInBytes];

            using(RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(bytes);
            }

            //TODO improvements/check if you can offload it to the handler/via event so it gets created else where and not here

            FantasyUserRefreshToken fantasyUserRefreshToken = new FantasyUserRefreshToken()
            {
                UserId = fantasyUser.Id,
                RefreshToken = Convert.ToBase64String(bytes),
                RefreshTokenExpirationTime = FantasyTokenSettings.RefreshTokenExpirationTimeInDays
            };

            FantasyUserDbContext.Add(fantasyUserRefreshToken);

            await FantasyUserDbContext.SaveChangesAsync();

            return fantasyUserRefreshToken; 
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
