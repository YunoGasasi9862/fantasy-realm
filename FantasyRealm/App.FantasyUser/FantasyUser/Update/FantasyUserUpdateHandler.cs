﻿using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using Core.App.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace App.FantasyUser.FantasyUser.Update
{
    public class FantasyUserUpdateHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserUpdateRequest, CommandResponse>
    {
        public FantasyUserUpdateHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
        }

        public async Task<CommandResponse> Handle(FantasyUserUpdateRequest request, CancellationToken cancellationToken)
        {
            if(await FantasyUserDbContext.FantasyUsers.AnyAsync(fu => fu.Id != request.Id && fu.Username.ToUpper() == request.Username.ToUpper().Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"Fantasy User - {request.Username} - with the same username exists in the database!");
            }

            var fantasyUser = await FantasyUserDbContext.FantasyUsers.SingleOrDefaultAsync(fu => fu.Id == request.Id, cancellationToken);

            if (fantasyUser is null)
            {
                return (CommandResponse)Error($"Fantasy User - {request.Username} - does not exist!");
            }

            fantasyUser = FantasyUserUpdateRequest.Copy(request, fantasyUser);

            FantasyUserDbContext.FantasyUsers.Update(fantasyUser);

            await FantasyUserDbContext.SaveChangesAsync(cancellationToken);

            return (CommandResponse)Success($"Fantasy User : {request.Username.ToString()}'s information successfully updated!", request.Id);
        }
    }
}
