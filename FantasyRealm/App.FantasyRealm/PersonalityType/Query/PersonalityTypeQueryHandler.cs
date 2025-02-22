using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using MediatR;

namespace App.FantasyRealm.PersonalityType.Query
{
    public class PersonalityTypeQueryHandler : FantasyRealmDBHandler, IRequestHandler<PersonalityTypeQueryRequest, IQueryable<PersonalityTypeQueryResponse>>
    {
        public PersonalityTypeQueryHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(fantasyRealmDBContext)
        {
        }

        public Task<IQueryable<PersonalityTypeQueryResponse>> Handle(PersonalityTypeQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(fantasyRealmDBContext.PersonalityTypes.OrderBy(pt => pt.Name).Select(pt => new PersonalityTypeQueryResponse()
            {
                Id = pt.Id,
                Name = pt.Name,
                Description = pt.Description,
            }));
        }
    }
}
