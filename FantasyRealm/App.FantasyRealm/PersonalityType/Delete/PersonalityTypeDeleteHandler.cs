using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Azure;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.PersonalityType.Delete
{
    public class PersonalityTypeDeleteHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityTypeDeleteRequest, CommandResponse>
    {
        public PersonalityTypeDeleteHandler(FantasyRealmDBContext fantasyRealmDbContext) : base(fantasyRealmDbContext)
        {
        }

        async Task<CommandResponse> IRequestHandler<PersonalityTypeDeleteRequest, CommandResponse>.Handle(PersonalityTypeDeleteRequest request, CancellationToken cancellationToken)
        {
            var personalityType = await fantasyRealmDBContext.PersonalityTypes.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (personalityType is null)
                return (CommandResponse)Error($"Personality Type - {request.Name} - does not exist!");

            fantasyRealmDBContext.PersonalityTypes.Remove(personalityType);
            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Personality Type: {request.ToString()} successfully removed!", request.Id);
        }
    }
}
