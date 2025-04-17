using App.FantasyUser.Domain;
using App.FantasyUser.Features;
using MediatR;

namespace App.FantasyUser.FantasyUser.Query
{
    public class FantasyUserQueryHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>
    {
        public FantasyUserQueryHandler(FantasyUserDbContext fantasyUserDbContext) : base(fantasyUserDbContext)
        {
        }

        Task<IQueryable<FantasyUserQueryResponse>> IRequestHandler<FantasyUserQueryRequest, IQueryable<FantasyUserQueryResponse>>.Handle(FantasyUserQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyUserDbContext.FantasyUsers.OrderBy(fu => fu.Name).Select(fu => new FantasyUserQueryResponse()
            {
                Id = fu.Id,
                Name = fu.Name,
                Surname = fu.Surname,
                Username = fu.Username,
                Email = fu.Email,
                Password = fu.Password,
                DateOfBirth = fu.DateOfBirth,
                ProfilePicturePath = fu.ProfilePicturePath,
            }));
        }
    }
}
