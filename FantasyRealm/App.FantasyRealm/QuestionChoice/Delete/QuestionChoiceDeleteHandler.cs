using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.QuestionChoice.Delete
{
    public class QuestionChoiceDeleteHandler : FantasyRealmDBHandler, IRequestHandler<QuestionChoiceDeleteRequest, CommandResponse>
    {
        public QuestionChoiceDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {

        }

        async Task<CommandResponse> IRequestHandler<QuestionChoiceDeleteRequest, CommandResponse>.Handle(QuestionChoiceDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.QuestionChoice questionChoice = await fantasyRealmDBContext.QuestionChoices.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (questionChoice is null)
            {
                return (CommandResponse)Error($"Question Choice - {request.Choice} - does not exist!");
            }

            fantasyRealmDBContext.QuestionChoices.Remove(questionChoice);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question Choice: {request.ToString()} successfully removed!", request.Id);
        }
    }
}
