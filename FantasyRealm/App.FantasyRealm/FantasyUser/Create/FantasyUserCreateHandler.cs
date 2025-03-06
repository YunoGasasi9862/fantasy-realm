
using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUser.Create
{
    public class FantasyUserCreateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserCreateRequest, CommandResponse>
    {
        public FantasyUserCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(FantasyUserCreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
