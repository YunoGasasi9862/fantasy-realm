

using App.FantasyUser.Domain;
using App.FantasyUser.FantasyUser.Contants;
using App.FantasyUser.FantasyUser.Create;
using App.FantasyUser.Features;
using Core.App.Domain;
using Core.App.Features;
using Core.App.Publishers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace App.FantasyUser.FantasyUserRole.Create
{
    public class FantasyUserRoleCreateHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleCreateRequest, CommandResponse>
    {
        private CancellationToken CancellationToken { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        public FantasyUserRoleCreateHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
            CancellationTokenSource = new CancellationTokenSource();

            CancellationToken = CancellationTokenSource.Token;
        }

        public async Task<CommandResponse> Handle(FantasyUserRoleCreateRequest request, CancellationToken cancellationToken)
        {
            if (await FantasyUserDbContext.FantasyUserRoles.AnyAsync(role => role.Name == request.Name.Trim()))
            {
                return (CommandResponse)Error($"Role {request.Name} already exists in the database - won't create a new one!");
            }

            Domain.FantasyUserRole fantasyUserRole = new Domain.FantasyUserRole()
            {
                Name = request.Name
            };

            FantasyUserDbContext.FantasyUserRoles.Add(fantasyUserRole);

            await FantasyUserDbContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"{request.Name} successfully created in the database!", fantasyUserRole.Id);
        }
    }
}
