
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserAccessTokenRequest, CommandResponse>
    {

        public FantasyUserAccessTokenHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserAccessTokenRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUser? fantasyUser = await FantasyUserDbContext.FantasyUsers.SingleOrDefaultAsync(user => user.Username == request.UserName.Trim() && user.Password == request.Password, cancellationToken);

            if (fantasyUser == null)
            {
                return new CommandResponse(false, $"User not found with the username {request.UserName}");
            }

            FantasyUserRefreshToken fantasyRefreshToken = await GenerateRefreshToken(fantasyUser);

            return new CommandResponse(true, $"Succesful!!");
        }
    }
}
