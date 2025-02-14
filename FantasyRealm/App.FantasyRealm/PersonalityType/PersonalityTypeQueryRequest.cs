

using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.PersonalityType
{
    public class PersonalityTypeQueryRequest: CommandRequest, IRequest<IQueryable<PersonalityTypeQueryResponse>>
    {
    }
}
