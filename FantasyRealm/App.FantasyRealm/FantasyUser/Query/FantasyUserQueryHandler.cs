using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.FantasyUser.Query
{
    public class FantasyUserQueryHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>
    {
        public FantasyUserQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        Task<IQueryable<FantasyUserQueryResponse>> IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>.Handle(FantasyUserQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyRealmDBContext.FantasyUsers.OrderBy(fu => fu.Name).Select(fu => new FantasyUserQueryResponse()
            {
                Id = fu.Id,
                Name = fu.Name,
                Surname = fu.Surname,
                Username = fu.Username,
                Email = fu.Email,
                Password = fu.Password,
                DateOfBirth = fu.DateOfBirth,
                ProfilePicture = fu.profilePicture,
            }));
        }
    }
}
