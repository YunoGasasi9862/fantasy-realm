
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace App.FantasyUser.FantasyUserRole.Delete
{
    public class FantasyUserRoleDeleteRequestHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleDeleteRequest, CommandResponse>
    {
        public FantasyUserRoleDeleteRequestHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {

        }

        public async Task<CommandResponse> Handle(FantasyUserRoleDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUserRole fantasyUserRole = await FantasyUserDbContext.FantasyUserRoles.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUserRole == null)
            {
                return (CommandResponse)Error($"fantasyUserRole with ID : - {request.Id} - does not exist!");
            }

            FantasyUserDbContext.FantasyUserRoles.Remove(fantasyUserRole);

            await FantasyUserDbContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy UserRole: {request.Id} - successfully removed!", request.Id);
        }
    }
}
