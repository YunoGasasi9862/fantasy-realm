using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.Question.Query
{
    public class QuestionQueryHandler : FantasyRealmDBHandler, IRequestHandler<QuestionQueryRequest, IQueryable<QuestionQueryResponse>>
    {
        public QuestionQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<QuestionQueryResponse>> Handle(QuestionQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
