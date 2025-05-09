
using Core.App.Features;
using MediatR;

namespace App.FantasyUser.FantasyUserRole.Query
{
    public class FantasyUserRoleQueryRequest: CommandResponse, IRequest<IQueryable<FantasyUserRoleQueryResponse>>
    {

    }
}
