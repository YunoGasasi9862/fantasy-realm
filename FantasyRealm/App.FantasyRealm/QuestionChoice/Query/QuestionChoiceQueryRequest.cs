using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.QuestionChoice.Query
{
    public class QuestionChoiceQueryRequest : CommandRequest, IRequest<IQueryable<QuestionChoiceQueryResponse>>
    {

    }
}
