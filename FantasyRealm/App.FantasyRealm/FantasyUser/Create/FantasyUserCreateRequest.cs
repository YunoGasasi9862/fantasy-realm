using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUser.Create
{
    public class FantasyUserCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
    }
}
