using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.Question.Update
{
    public class QuestionUpdateHandler : FantasyRealmDBHandler, IRequestHandler<QuestionUpdateRequest, CommandResponse>
    {
        public QuestionUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(QuestionUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.Questions.AnyAsync(t => t.Id != request.Id && t.Verbiage.ToUpper() == request.Verbiage.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Question - {request.Verbiage} - with the same description already exists in the database!");
            }

            var question = await fantasyRealmDBContext.Questions.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (question is null)
            {
                return (CommandResponse)Error($"Question - {request.Verbiage} - does not exist!");
            }


            question = QuestionUpdateRequest.Copy(request, question);

            fantasyRealmDBContext.Questions.Update(question);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question description: {request.Verbiage.ToString()} successfully updated!", request.Id);
        }
    }
}
