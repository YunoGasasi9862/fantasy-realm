using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.QuestionChoice.Create
{
    public class QuestionChoiceCreateHandler : FantasyRealmDBHandler, IRequestHandler<QuestionChoiceCreateRequest, CommandResponse>
    {
        public QuestionChoiceCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(QuestionChoiceCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.QuestionChoices.AnyAsync(pt => pt.Choice.ToUpper() == request.Choice.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Question Choice - {request.Choice} - already exists in the database!");
            }

            fantasyRealmDBContext.QuestionChoices.Add(new Domain.QuestionChoice
            {
                QuestionId = request.QuestionId,
                Choice = request.Choice.Trim(),
            });

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question Choice: {request.Choice.ToString()} successfully created!", request.Id);
        }
    }
}
