using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.PersonalityAnswer.Update
{
    public class PersonalityAnswerUpdateHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityAnswerUpdateRequest, CommandResponse>
    {
        public PersonalityAnswerUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(PersonalityAnswerUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.PersonalityAnswers.AnyAsync(p => p.Id != request.Id  &&
                p.PersonalityTypeId == request.PersonalityTypeId &&
                p.QuestionId == request.QuestionId &&
                p.ChoiceId == request.ChoiceId, cancellationToken
            ))
            {
                return (CommandResponse)Error($"Personality Answer relation already exists in the database!");
            }

            var personalityAnswer = await fantasyRealmDBContext.PersonalityAnswers.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (personalityAnswer is null) 
            {
                return (CommandResponse)Error($"Personality Answer relations does not exist!");
            }

            personalityAnswer = PersonalityAnswerUpdateRequest.Copy(request, personalityAnswer);

            fantasyRealmDBContext.PersonalityAnswers.Update(personalityAnswer);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Personality Answer relation: {request.ToString()} successfully updated!", request.Id);
        }
    }
}
