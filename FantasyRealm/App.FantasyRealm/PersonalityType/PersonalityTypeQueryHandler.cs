using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Azure.Core;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.PersonalityType
{
    public class PersonalityTypeQueryHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityTypeQueryRequest, IQueryable<PersonalityTypeQueryResponse>>
    {
        public PersonalityTypeQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<PersonalityTypeQueryResponse>> Handle(PersonalityTypeQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
