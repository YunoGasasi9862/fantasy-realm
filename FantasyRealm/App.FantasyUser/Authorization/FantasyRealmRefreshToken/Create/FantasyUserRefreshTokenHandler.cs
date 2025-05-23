﻿using App.FantasyUser.Authorization.Common;
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;

namespace App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create
{
    public class FantasyUserRefreshTokenHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRefreshTokenRequest, FantasyUserRefreshTokenResponse>, IRequestHandler<FantasyUserRefreshTokenNotificationRequest, FantasyUserRefreshTokenNotificationResponse>
    {
        private IMediator Mediator { get; set; }
        public FantasyUserRefreshTokenHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings, IMediator mediator) : base(fantasyUserDbContext, accessTokenSettings)
        {
            Mediator = mediator;
        }

        public async Task<FantasyUserRefreshTokenNotificationResponse> Handle(FantasyUserRefreshTokenNotificationRequest request, CancellationToken cancellationToken)
        {
            FantasyUserRefreshTokenNotificationResponse fantasyUserRefreshToken = await CreateFantasyUserRefreshToken(request.FantasyUser);

            return fantasyUserRefreshToken;
        }

        public async Task<FantasyUserRefreshTokenResponse> Handle(FantasyUserRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal =  GetClaimsPrincipal(request.AccessToken);

            int userId = Convert.ToInt32(principal?.Claims.SingleOrDefault(claim => claim.Type == "Id")?.Value);

            request.RefreshToken = request.RefreshToken.StartsWith(JwtBearerDefaults.AuthenticationScheme) ?
               request.RefreshToken.Remove(0, JwtBearerDefaults.AuthenticationScheme.Length + 1) : request.RefreshToken;

            Domain.FantasyUser? fantasyUser = FantasyUserDbContext.FantasyUsers.Include(user => user.Role)
                .Include(token => token.FantasyUserRefreshToken)
                .SingleOrDefault(user => user.Id == userId && user.FantasyUserRefreshToken.RefreshToken == request.RefreshToken &&
                                  user.FantasyUserRefreshToken.RefreshTokenExpirationTime >= DateTime.Now);

            if (fantasyUser == null)
            {
                return new FantasyUserRefreshTokenResponse(false, "User Not Found or the refresh token has expired!");
            }

            FantasyUserRefreshTokenNotificationResponse refreshToken = await CreateFantasyUserRefreshToken(fantasyUser);

            List<Claim> claims = GetClaims(fantasyUser);
            string accessToken = CreateAccessToken(claims, DateTime.Now.AddMinutes(FantasyTokenSettings.ExpirationInMinutes));

            return new FantasyUserRefreshTokenResponse(true, $"Successfully generated the refresh token for the user: {fantasyUser.Name}", fantasyUser.Id)
            {
                AccessToken = accessToken,

                RefreshToken = $"{JwtBearerDefaults.AuthenticationScheme} {refreshToken.RefreshToken}"
            };
        }

        protected async Task<FantasyUserRefreshTokenNotificationResponse> CreateFantasyUserRefreshToken(Domain.FantasyUser? fantasyUser)
        {
            if (fantasyUser == null)
            {
                throw new ApplicationException($"Provided user is null!");
            }

            byte[] bytes = new byte[FantasyTokenSettings.RefreshTokenLengthInBytes];

            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(bytes);
            }

            FantasyUserRefreshToken fantasyUserRefreshToken = FantasyUserDbContext.RefreshTokens.Include(token => token.FantasyUser)
            .SingleOrDefault(token => token.UserId == fantasyUser.Id) ?? new FantasyUserRefreshToken();

            fantasyUserRefreshToken.UserId = fantasyUser.Id;
            fantasyUserRefreshToken.RefreshToken = Convert.ToBase64String(bytes);
            fantasyUserRefreshToken.RefreshTokenExpirationTime = DateTime.Now.AddDays(FantasyTokenSettings.RefreshTokenExpirationTimeInDays);

            //for separation of concerns, its better to have it in a separate handler (where we have an endpoint to take the update request)
            //for now given the time constraints, its fine
             _ = FantasyUserDbContext.RefreshTokens.Include(token => token.FantasyUser).Any(token => token.UserId == fantasyUser.Id) ? FantasyUserDbContext.RefreshTokens.Update(fantasyUserRefreshToken) : FantasyUserDbContext.RefreshTokens.Add(fantasyUserRefreshToken);

            await FantasyUserDbContext.SaveChangesAsync();

            return new FantasyUserRefreshTokenNotificationResponse()
            { 
                RefreshToken = fantasyUserRefreshToken.RefreshToken,
            };
        }
    }
}
