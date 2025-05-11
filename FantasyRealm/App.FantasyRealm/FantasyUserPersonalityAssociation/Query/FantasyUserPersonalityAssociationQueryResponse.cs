using Core.App.Features;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.Query
{
    public class FantasyUserPersonalityAssociationQueryResponse : QueryResponse
    {
        public int FantasyUserId { get; set; }

        public int PersonalityTypeId { get; set; }
    }
}
