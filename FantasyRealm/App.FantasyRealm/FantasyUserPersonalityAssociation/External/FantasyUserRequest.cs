

using App.FantasyRealm.FantasyUserPersonalityAssociation.External;
using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Request
{
    //due to time constraints, couldn't finish it
    public class FantasyUserRequest: CommandRequest, IRequest<FantasyUserResponse>
    {
        public String UserName { get; set; }
    }
}
