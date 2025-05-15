

using Core.App.Features;
using Core.App.Interfaces;

namespace App.FantasyRealm.FantasyUserPersonalityAssociation.External
{
    public class FantasyUserResponse: CommandResponse
    {
        public FantasyUserResponse() { }

        public int FantasyUserId { get; set; }
    }
}
