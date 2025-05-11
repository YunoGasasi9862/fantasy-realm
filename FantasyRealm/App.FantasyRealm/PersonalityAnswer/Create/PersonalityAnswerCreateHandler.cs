using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.PersonalityAnswer.Create
{
    public class PersonalityAnswerCreateHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityAnswerCreateRequest, CommandResponse>
    {
        public PersonalityAnswerCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(PersonalityAnswerCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.PersonalityAnswers.AnyAsync(pa =>
                pa.PersonalityTypeId == request.PersonalityTypeId &&
                pa.QuestionId == request.QuestionId &&
                pa.ChoiceId == request.ChoiceId, cancellationToken))
            {
                return (CommandResponse)Error($"This personality answer mapping already exists in the database!");
            }

            fantasyRealmDBContext.PersonalityAnswers.Add(new Domain.PersonalityAnswer
            {
                PersonalityTypeId = request.PersonalityTypeId,
                QuestionId = request.QuestionId,
                ChoiceId = request.ChoiceId,
            });

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse) Success($"Personality Answer relation: {request.ToString()} successfully created!", request.Id);


        }
    }
}
