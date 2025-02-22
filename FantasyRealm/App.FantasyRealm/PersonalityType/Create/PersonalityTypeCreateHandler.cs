using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyRealm.PersonalityType.Create
{
    public class PersonalityTypeCreateHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityTypeCreateRequest, ICommandResponse>
    {
        public PersonalityTypeCreateHandler(FantasyRealmDBContext fantasyRealmDbContext) : base(fantasyRealmDbContext)
        {

        }

        public async Task<ICommandResponse> Handle(PersonalityTypeCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.PersonalityTypes.AnyAsync(pt => pt.Name.ToLower().Trim().Equals(request.Name.ToLower().Trim()), cancellationToken))
            {
                return Error($"Personality Type - {request.Name} - already exists in the database!");
            }

            fantasyRealmDBContext.PersonalityTypes.Add(new Domain.PersonalityType
            {
                Name = request.Name,
            });

            await fantasyRealmDBContext.SaveChangesAsync();

            return Success($"Personality Type: {request.ToString()} successfully created!", request.Id);
        }
    }
}
