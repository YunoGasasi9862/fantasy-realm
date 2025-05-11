using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.PersonalityAnswer.Query
{
    public class PersonalityAnswerQueryRequest : CommandRequest, IRequest<IQueryable<PersonalityAnswerQueryResponse>>
    {
    }
}
