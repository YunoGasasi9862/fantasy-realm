using Core.App.Features;
using MediatR;

namespace App.FantasyUser.FantasyUserRole.Delete
{
    public class FantasyUserRoleDeleteRequest : CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserRoleDeleteRequest() { }
        public string Name { get; set; }
    }
}
