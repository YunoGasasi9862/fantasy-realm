using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Update
{
    public class FantasyUserPersonalityAssociationUpdateRequest : CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int FantasyUserId { get; set; }

        [Required]
        public int PersonalityTypeId { get; set; }

        public static Domain.FantasyUserPersonalityAssociation Copy(FantasyUserPersonalityAssociationUpdateRequest request, Domain.FantasyUserPersonalityAssociation fantasyUserPersonalityAssociation)
        {
            fantasyUserPersonalityAssociation.FantasyUserId = request.FantasyUserId;
            fantasyUserPersonalityAssociation.PersonalityTypeId = request.PersonalityTypeId;

            return fantasyUserPersonalityAssociation;
        }

        public override string ToString()
        {
            return $"FantasyUserId : {FantasyUserId}, PersonalityTypeId: {PersonalityTypeId}";
        }
    }
}
