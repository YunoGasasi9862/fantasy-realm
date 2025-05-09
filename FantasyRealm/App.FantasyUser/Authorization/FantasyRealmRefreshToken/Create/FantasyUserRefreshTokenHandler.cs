using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create
{
    public class FantasyUserRefreshTokenHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRefreshTokenRequest, FantasyUserRefreshTokenResponse>
    {
        public FantasyUserRefreshTokenHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
        }

        public Task<FantasyUserRefreshTokenResponse> Handle(FantasyUserRefreshTokenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
