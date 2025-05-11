using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Delete
{
    public class FantasyUserPersonalityAssociationDeleteRequest : CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserPersonalityAssociationDeleteRequest() { }
        public int FantasyUserId { get; set; }

        public int PersonalityTypeId { get; set; }
    }
}
