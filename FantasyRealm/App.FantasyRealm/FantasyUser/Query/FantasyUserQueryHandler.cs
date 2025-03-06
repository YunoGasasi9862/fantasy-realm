using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUser.Query
{
    public class FantasyUserQueryHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>
    {
        public FantasyUserQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        Task<IQueryable<FantasyUserQueryResponse>> IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>.Handle(FantasyUserQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
