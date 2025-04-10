using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyRealmAccessTokenHandler : FantasyRealmDBHandler, IRequestHandler<FantasyRealmAccessTokenRequest, CommandResponse>
    {
        public FantasyRealmAccessTokenHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(FantasyRealmAccessTokenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
