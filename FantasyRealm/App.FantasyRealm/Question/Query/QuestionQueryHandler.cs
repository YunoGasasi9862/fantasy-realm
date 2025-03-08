using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using App.FantasyRealm.PersonalityType.Query;
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
            return Task.FromResult(fantasyRealmDBContext.Questions.OrderBy(q => q.Verbiage).Select(q => new QuestionQueryResponse()
            {
                Id = q.Id,
                Verbiage = q.Verbiage,
            }));
        }
    }
}
