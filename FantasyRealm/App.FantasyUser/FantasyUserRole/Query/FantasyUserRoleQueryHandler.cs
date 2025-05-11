using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using MediatR;
using Microsoft.Extensions.Options;

namespace App.FantasyUser.FantasyUserRole.Query
{
    public class FantasyUserRoleQueryHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserRoleQueryRequest, IQueryable<FantasyUserRoleQueryResponse>>
    {
        public FantasyUserRoleQueryHandler(FantasyUserDbContext fantasyUserDbContext, IOptions<AccessTokenSettings> accessTokenSettings) : base(fantasyUserDbContext, accessTokenSettings)
        {
        }

        Task<IQueryable<FantasyUserRoleQueryResponse>> IRequestHandler<FantasyUserRoleQueryRequest, IQueryable<FantasyUserRoleQueryResponse>>.Handle(FantasyUserRoleQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(FantasyUserDbContext.FantasyUserRoles.OrderBy(fu => fu.Name).Select(fu => new FantasyUserRoleQueryResponse()
            {
                Id = fu.Id,
                Name = fu.Name,
            }));
        }
    }
}
