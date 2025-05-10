
using App.FantasyUser.Authorization.Common;
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserAccessTokenRequest, FantasyUserAccessTokenResponse>
    {
        private IMediator Mediator { get; set; }

        public FantasyUserAccessTokenHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings, IMediator mediator) : base(fantasyUserDbContext, accessTokenSettings)
        {
            Mediator = mediator;
        }

        public async Task<FantasyUserAccessTokenResponse> Handle(FantasyUserAccessTokenRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUser? fantasyUser = await FantasyUserDbContext.FantasyUsers.SingleOrDefaultAsync(user => user.Username == request.UserName.Trim() && user.Password == request.Password, cancellationToken);

            if (fantasyUser == null)
            {
                return new FantasyUserAccessTokenResponse(false, $"User not found with the username {request.UserName}");
            }

            //publishes an event to generate refresh token :)
            FantasyUserRefreshTokenNotificationResponse refreshToken = await Mediator.Send(new FantasyUserRefreshTokenNotificationRequest(fantasyUser), cancellationToken);

            //now create claims and access token
            List<Claim> claims = GetClaims(fantasyUser);
            string accessToken = CreateAccessToken(claims, DateTime.Now.AddMinutes(FantasyTokenSettings.ExpirationInMinutes));

            return new FantasyUserAccessTokenResponse(true, $"Successfully generated the refresh token for the user: {fantasyUser.Name}", fantasyUser.Id)
            {
                AccessToken = accessToken,

                RefreshToken = $"{JwtBearerDefaults.AuthenticationScheme} {refreshToken.RefreshToken}"
            };
        }
    }
}
