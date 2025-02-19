using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.PersonalityType.Query
{
    public class PersonalityTypeQueryRequest : CommandRequest, IRequest<IQueryable<PersonalityTypeQueryResponse>>
    {
    }
}
