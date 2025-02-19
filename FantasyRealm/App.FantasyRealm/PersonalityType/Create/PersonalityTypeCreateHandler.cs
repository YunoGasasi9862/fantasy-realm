using App.FantasyRealm.Domain;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.PersonalityType.Create
{
    public class PersonalityTypeCreateHandler : FantasyRealmDBContext, IRequestHandler<PersonalityTypeCreateRequest, CommandResponse>
    {
        public PersonalityTypeCreateHandler(DbContextOptions<FantasyRealmDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public Task<CommandResponse> Handle(PersonalityTypeCreateRequest request, CancellationToken cancellationToken)
        {
            //for boran to do
            throw new NotImplementedException();
        }
    }
}
