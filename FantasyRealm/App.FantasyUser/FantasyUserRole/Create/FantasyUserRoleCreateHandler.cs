

using App.FantasyUser.Domain;
using App.FantasyUser.FantasyUser.Create;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyUser.FantasyUserRole.Create
{
    public class FantasyUserRoleCreateHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleCreateRequest, CommandResponse>
    {
        private CancellationToken CancellationToken { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        public FantasyUserRoleCreateHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
            CancellationTokenSource = new CancellationTokenSource();

            CancellationToken = CancellationTokenSource.Token;
        }

        public async Task<CommandResponse> Handle(FantasyUserRoleCreateRequest request, CancellationToken cancellationToken)
        {
            return (CommandResponse)Success($"{request.ToString()} successfully created in the database!", request.Id);
        }
    }
}
