using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Query
{
    public class FantasyUserPersonalityAssociationQueryRequest : CommandRequest, IRequest<IQueryable<FantasyUserPersonalityAssociationQueryResponse>>
    {
    }
}
