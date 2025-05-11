using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace App.FantasyUser.FantasyUserRole.Update
{
    public class FantasyUserRoleUpdateHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleUpdateRequest, CommandResponse>
    {
        public FantasyUserRoleUpdateHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserRoleUpdateRequest request, CancellationToken cancellationToken)
        {
            if(await FantasyUserDbContext.FantasyUserRoles.AnyAsync(fu => fu.Id != request.Id && fu.Name.ToUpper() == request.Name.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Fantasy User Role - {request.Name} - with the same username exists in the database!");
            }

            var fantasyUserRole = await FantasyUserDbContext.FantasyUserRoles.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUserRole is null)
            {
                return (CommandResponse)Error($"Fantasy User Role - {request.Name} - does not exist!");
            }

            fantasyUserRole = FantasyUserRoleUpdateRequest.Copy(request, fantasyUserRole);

            FantasyUserDbContext.FantasyUserRoles.Update(fantasyUserRole);

            await FantasyUserDbContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy User Role: {request.Name.ToString()}'s information successfully updated!", request.Id);
        }
    }
}
