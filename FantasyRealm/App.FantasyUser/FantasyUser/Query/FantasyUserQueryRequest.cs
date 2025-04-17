
using Core.App.Features;
using MediatR;

namespace App.FantasyUser.FantasyUser.Query
{
    public class FantasyUserQueryRequest: CommandResponse, IRequest<IQueryable<FantasyUserQueryResponse>>
    {
    }
}
