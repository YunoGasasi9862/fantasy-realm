
using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Question.Create
{
    public class QuestionCreateHandler : FantasyRealmDBHandler, IRequestHandler<QuestionCreateRequest, CommandResponse>
    {
        public QuestionCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(QuestionCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.Questions.AnyAsync(p => p.Verbiage.ToUpper() == request.Verbiage.ToUpper().Trim(), cancellationToken))
                return (CommandResponse) Error("Question with the same description exists!");


            fantasyRealmDBContext.Questions.Add(new Domain.Question
            {
                Verbiage = request.Verbiage.Trim(),
            });

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question description: {request.ToString()} successfully created!", request.Id);
        }
    }
}
