using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Delete
{
    public class FantasyUserPersonalityAssociationDeleteHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserPersonalityAssociationDeleteRequest, CommandResponse>
    {
        public FantasyUserPersonalityAssociationDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        async Task<CommandResponse> IRequestHandler<FantasyUserPersonalityAssociationDeleteRequest, CommandResponse>.Handle(FantasyUserPersonalityAssociationDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUserPersonalityAssociation fantasyUserPersonalityAssociation = await fantasyRealmDBContext.FantsayUserPersonalityAssociations.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (fantasyUserPersonalityAssociation is null)
            {
                return (CommandResponse)Error($"Personality Association between: {request.FantasyUserId} and {request.PersonalityTypeId} does not exist!");
            }

            fantasyRealmDBContext.FantsayUserPersonalityAssociations.Remove(fantasyUserPersonalityAssociation);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Personality Association between: {request.FantasyUserId} and {request.PersonalityTypeId} successfully removed!", request.Id);
        }
    }
}
