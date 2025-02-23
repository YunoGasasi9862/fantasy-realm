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

namespace App.FantasyRealm.PersonalityType.Update
{
    public class PersonalityTypeUpdateHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityTypeUpdateRequest, CommandResponse>
    {
        public PersonalityTypeUpdateHandler(FantasyRealmDBContext fantasyRealmDbContext) : base(fantasyRealmDbContext)
        {
        }

        public async Task<CommandResponse> Handle(PersonalityTypeUpdateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.PersonalityTypes.AnyAsync(t => t.Id != request.Id && t.Name.ToUpper() == request.Name.ToUpper().Trim(), cancellationToken))
                return (CommandResponse)Error($"Personality Type - {request.Name} - with the same name already exists in the database!");

            var personalityType = await fantasyRealmDBContext.PersonalityTypes.SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if(personalityType is null)
                return (CommandResponse)Error($"Personality Type - {request.Name} - does not exist!");

            personalityType.Name = request.Name.Trim();
            fantasyRealmDBContext.PersonalityTypes.Update(personalityType);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Personality Type: {request.ToString()} successfully updated!", request.Id);
        }
    }
}
