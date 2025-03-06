using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.FantasyUser.Update
{
    public class FantasyUserUpdateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserUpdateRequest, CommandResponse>
    {
        public FantasyUserUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<CommandResponse> Handle(FantasyUserUpdateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
