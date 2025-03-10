using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.QuestionChoice.Create
{
    public class QuestionChoiceCreateHandler
    {
        public QuestionChoiceCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(QuestionChoiceCreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
