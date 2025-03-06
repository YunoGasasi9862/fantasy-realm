using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;


namespace App.FantasyRealm.FantasyUser.Delete
{
    public class FantasyUserDeleteHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserDeleteRequest, CommandResponse>
    {
        public FantasyUserDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(FantasyUserDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
