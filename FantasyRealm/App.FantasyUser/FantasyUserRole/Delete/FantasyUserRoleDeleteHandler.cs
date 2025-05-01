
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;


namespace App.FantasyUser.FantasyUserRole.Delete
{
    public class FantasyUserRoleDeleteRequestHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleDeleteRequest, CommandResponse>
    {
        public FantasyUserRoleDeleteRequestHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {

        }

        public async Task<CommandResponse> Handle(FantasyUserRoleDeleteRequest request, CancellationToken cancellationToken)
        {
            return (CommandResponse)Success($"Fantasy UserRole: {request.Name} - successfully removed!", request.Id);
        }
    }
}
