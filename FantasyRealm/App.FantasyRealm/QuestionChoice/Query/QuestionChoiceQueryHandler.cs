using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.QuestionChoice.Query
{
    public class QuestionChoiceQueryHandler : FantasyRealmDBHandler, IRequestHandler<QuestionChoiceQueryRequest, IQueryable<QuestionChoiceQueryResponse>>
    {
        public QuestionChoiceQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<QuestionChoiceQueryResponse>> Handle(QuestionChoiceQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyRealmDBContext.QuestionChoices.OrderBy(qc => qc.Choice).Select(qc => new QuestionChoiceQueryResponse()
            {
                Id = qc.Id,
                QuestionId = qc.QuestionId,
                Choice = qc.Choice,
            }));
        }
    }
}
