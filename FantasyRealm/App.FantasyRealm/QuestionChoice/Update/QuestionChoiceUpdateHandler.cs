using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.QuestionChoice.Update
{
    public class QuestionChoiceUpdateHandler : FantasyRealmDBHandler, IRequestHandler<QuestionChoiceUpdateRequest, CommandResponse>
    {
        public QuestionChoiceUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {

        }

        public async Task<CommandResponse> Handle(QuestionChoiceUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.QuestionChoices.AnyAsync(t => t.Id != request.Id && t.Choice.ToUpper() == request.Choice.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Question Choice - {request.Choice} - with the same name already exists in the database!");
            }

            var questionChoice = await fantasyRealmDBContext.QuestionChoices.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (questionChoice is null)
            {
                return (CommandResponse)Error($"Question Choice - {request.Choice} - does not exist!");
            }


            questionChoice = QuestionChoiceUpdateRequest.Copy(request, questionChoice);

            fantasyRealmDBContext.QuestionChoices.Update(questionChoice);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question Choice: {request.Choice.ToString()} successfully updated!", request.Id);
        }
    }
}
