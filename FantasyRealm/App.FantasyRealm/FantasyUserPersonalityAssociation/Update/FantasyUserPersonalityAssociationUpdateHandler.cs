using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Update
{
    public class FantasyUserPersonalityAssociationUpdateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserPersonalityAssociationUpdateRequest, CommandResponse>
    {
        public FantasyUserPersonalityAssociationUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserPersonalityAssociationUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.FantsayUserPersonalityAssociations
                .AnyAsync(x =>
                    x.Id != request.Id &&
                    x.FantasyUserId == request.FantasyUserId &&
                    x.PersonalityTypeId == request.PersonalityTypeId,
                    cancellationToken))
            {
                return (CommandResponse)Error($"Association between user ID {request.FantasyUserId} and personality type ID {request.PersonalityTypeId} already exists in the database!");
            }

            var fantasyUserPersonalityAssociation = await fantasyRealmDBContext.FantsayUserPersonalityAssociations.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (fantasyUserPersonalityAssociation is null)
            {
                return (CommandResponse)Error($"Association between user ID {request.FantasyUserId} and personality type ID {request.PersonalityTypeId} does not exists in the database!");
            }

            fantasyUserPersonalityAssociation = FantasyUserPersonalityAssociationUpdateRequest.Copy(request, fantasyUserPersonalityAssociation);

            fantasyRealmDBContext.FantsayUserPersonalityAssociations.Update(fantasyUserPersonalityAssociation);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Association between user ID {request.FantasyUserId} and personality type ID {request.PersonalityTypeId} created in the database!", request.Id);
        }
    }
}
