using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.PersonalityAnswer.Delete
{
    public class PersonalityAnswerDeleteHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityAnswerDeleteRequest, CommandResponse>
    {
        public PersonalityAnswerDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        async Task<CommandResponse> IRequestHandler<PersonalityAnswerDeleteRequest, CommandResponse>.Handle(PersonalityAnswerDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.PersonalityAnswer personalityAnswer = await fantasyRealmDBContext.PersonalityAnswers.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (personalityAnswer == null) 
            {
                return (CommandResponse)Error($"Personality Answer relation does not exist!");
            }

            fantasyRealmDBContext.PersonalityAnswers.Remove(personalityAnswer);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Personality Answer relation successfully removed!", request.Id);
        }
    }
}
