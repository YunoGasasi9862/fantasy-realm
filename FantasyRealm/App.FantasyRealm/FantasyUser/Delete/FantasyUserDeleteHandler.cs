using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.FantasyRealm.FantasyUser.Delete
{
    public class FantasyUserDeleteHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserDeleteRequest, CommandResponse>
    {
        public FantasyUserDeleteHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {

        }

        public async Task<CommandResponse> Handle(FantasyUserDeleteRequest request, CancellationToken cancellationToken)
        {
            Domain.FantasyUser fantasyUser = await fantasyRealmDBContext.FantasyUsers.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUser is null)
            {
                return (CommandResponse)Error($"Fantasy User: - {request.Name} - does not exist!");
            }

            fantasyRealmDBContext.FantasyUsers.Remove(fantasyUser);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy User: {request.Name} - {request.Surname} successfully removed!", request.Id);
        }
    }
}
