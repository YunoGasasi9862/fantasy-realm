using App.FantasyRealm.FantasyUserPersonalityAssociation.External;
using App.FantasyRealm.FantasyUserPersonalityAssociation.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyUser.FantasyUser.External
{
    public class FantasyUserExternalHandler : IRequestHandler<FantasyUserRequest, FantasyUserResponse>
    {
        public Task<FantasyUserResponse> Handle(FantasyUserRequest request, CancellationToken cancellationToken)
        {
            //due to time constraints
            throw new NotImplementedException();
        }
    }
}
