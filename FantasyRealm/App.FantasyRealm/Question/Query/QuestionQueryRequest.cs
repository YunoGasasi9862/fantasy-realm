using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.Question.Query
{
    public class QuestionQueryRequest : CommandRequest, IRequest<IQueryable<QuestionQueryResponse>>
    {

    }
}
