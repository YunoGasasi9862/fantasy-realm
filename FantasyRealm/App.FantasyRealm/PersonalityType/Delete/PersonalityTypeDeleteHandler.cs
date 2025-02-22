using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
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

        Task<CommandResponse> IRequestHandler<PersonalityTypeDeleteRequest, CommandResponse>.Handle(PersonalityTypeDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
