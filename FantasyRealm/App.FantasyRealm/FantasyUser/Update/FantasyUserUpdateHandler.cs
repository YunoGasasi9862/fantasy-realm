using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.FantasyRealm.FantasyUser.Update
{
    public class FantasyUserUpdateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserUpdateRequest, CommandResponse>
    {
        public FantasyUserUpdateHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserUpdateRequest request, CancellationToken cancellationToken)
        {
            if(await fantasyRealmDBContext.FantasyUsers.AnyAsync(fu => fu.Id != request.Id && fu.Username.ToUpper() == request.Username.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Fantasy User - {request.Username} - with the same username exists in the database!");
            }

            var fantasyUser = await fantasyRealmDBContext.FantasyUsers.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUser is null)
            {
                return (CommandResponse)Error($"Fantasy User - {request.Username} - does not exist!");
            }

            fantasyUser = FantasyUserUpdateRequest.Copy(request, fantasyUser);

            fantasyRealmDBContext.FantasyUsers.Update(fantasyUser);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy User : {request.Username.ToString()}'s information successfully updated!", request.Id);
        }
    }
}
