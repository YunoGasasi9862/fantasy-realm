using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Query
{
    public class FantasyUserPersonalityAssociationQueryHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserPersonalityAssociationQueryRequest, IQueryable<FantasyUserPersonalityAssociationQueryResponse>>
    {
        public FantasyUserPersonalityAssociationQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<FantasyUserPersonalityAssociationQueryResponse>> Handle(FantasyUserPersonalityAssociationQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyRealmDBContext.FantsayUserPersonalityAssociations.OrderBy(x => x.Id).Select(x => new FantasyUserPersonalityAssociationQueryResponse()
            {
                Id = x.Id,
                FantasyUserId = x.FantasyUserId,
                PersonalityTypeId = x.PersonalityTypeId,
            }));
        }
    }
}
