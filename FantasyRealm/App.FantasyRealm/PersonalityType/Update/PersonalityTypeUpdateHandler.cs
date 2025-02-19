using App.FantasyRealm.Domain;
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
    public class PersonalityTypeUpdateHandler : FantasyRealmDBContext, IRequestHandler<PersonalityTypeUpdateRequest, CommandResponse>
    {
        public PersonalityTypeUpdateHandler(DbContextOptions<FantasyRealmDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public Task<CommandResponse> Handle(PersonalityTypeUpdateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
