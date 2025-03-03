
using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.Question.Create
{
    public class QuestionCreateHandler : FantasyRealmDBHandler, IRequestHandler<QuestionCreateRequest, CommandResponse>
    {
        public QuestionCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(QuestionCreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
