using Core.App.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Create
{
    public class FantasyUserPersonalityAssociationCreateRequest : CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserPersonalityAssociationCreateRequest() { }

        public int FantasyUserId { get; set; }
        
        public int PersonalityTypeId { get; set; }
    }
}
