using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Create
{
    public class FantasyUserPersonalityAssociationCreateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserPersonalityAssociationCreateRequest, CommandResponse>
    {
        public FantasyUserPersonalityAssociationCreateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserPersonalityAssociationCreateRequest request, CancellationToken cancellationToken)
        {
            //i think we forgot to fix this ;-;
            //the better way is to ask for this data from the microservice B
            if(await fantasyRealmDBContext.FantsayUserPersonalityAssociations.AnyAsync(a => a.FantasyUserId == request.FantasyUserId && a.PersonalityTypeId == request.PersonalityTypeId, cancellationToken))
            {
                return (CommandResponse)Error($"Association between - {request.FantasyUserId} and {request.PersonalityTypeId} - already exists in the database!");
            }

            fantasyRealmDBContext.FantsayUserPersonalityAssociations.Add(new Domain.FantasyUserPersonalityAssociation
            {
                FantasyUserId = request.FantasyUserId,
                PersonalityTypeId = request.PersonalityTypeId,
            });

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Association between {request.FantasyUserId} and {request.PersonalityTypeId} created!", request.Id);
        }
    }
}
