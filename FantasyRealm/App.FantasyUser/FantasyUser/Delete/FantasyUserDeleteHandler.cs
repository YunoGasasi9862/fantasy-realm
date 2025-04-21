using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.FantasyUser.FantasyUser.Delete
{
    public class FantasyUserDeleteHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserDeleteRequest, CommandResponse>
    {
        public FantasyUserDeleteHandler(FantasyUserDbContext fantasyUserDbContext, AccessTokenSettings accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {

        }

        public async Task<CommandResponse> Handle(FantasyUserDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUser fantasyUser = await FantasyUserDbContext.FantasyUsers.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUser is null)
            {
                return (CommandResponse)Error($"Fantasy User: - {request.Name} - does not exist!");
            }

            FantasyUserDbContext.FantasyUsers.Remove(fantasyUser);

            await FantasyUserDbContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy User: {request.Name} - {request.Surname} successfully removed!", request.Id);
        }
    }
}
