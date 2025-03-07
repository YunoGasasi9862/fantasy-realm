using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Question.Delete
{
    public class QuestionDeleteHandler : FantasyRealmDBHandler, IRequestHandler<QuestionDeleteRequest, CommandResponse>
    {
        public QuestionDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(QuestionDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.Question question = await fantasyRealmDBContext.Question.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (question is null) 
            {
                return (CommandResponse)Error($"Question: - {request.Verbiage} - does not exist!");
            }

            fantasyRealmDBContext.Question.Remove(question);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Question: {request.Verbiage} successfully removed!", request.Id);
        }
    }
}
