
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserAccessTokenRequest, CommandResponse>
    {
        public FantasyUserAccessTokenHandler(FantasyUserDbContext fantasyUserDbContext) : base(fantasyUserDbContext)
        {
        }

        public Task<CommandResponse> Handle(FantasyUserAccessTokenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
