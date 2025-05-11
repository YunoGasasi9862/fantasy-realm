using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.PersonalityAnswer.Query
{
    public class PersonalityAnswerQueryHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityAnswerQueryRequest, IQueryable<PersonalityAnswerQueryResponse>>
    {
        public PersonalityAnswerQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<PersonalityAnswerQueryResponse>> Handle(PersonalityAnswerQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyRealmDBContext.PersonalityAnswers.OrderBy(x => x.Id).Select(x => new PersonalityAnswerQueryResponse()
            {
                Id = x.Id,
                PersonalityTypeId = x.PersonalityTypeId,
                QuestionId = x.QuestionId,
                ChoiceId = x.ChoiceId,
            }));
        }
    }
}
