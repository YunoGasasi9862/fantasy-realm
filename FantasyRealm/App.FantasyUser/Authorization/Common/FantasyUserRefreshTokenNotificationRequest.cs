using MediatR;

namespace App.FantasyUser.Authorization.Common
{
    public class FantasyUserRefreshTokenNotificationRequest : IRequest<FantasyUserRefreshTokenNotificationResponse>
    {
        public Domain.FantasyUser? FantasyUser { get; set; }

        public FantasyUserRefreshTokenNotificationRequest() { }

        public FantasyUserRefreshTokenNotificationRequest(Domain.FantasyUser? fantasyUser)
        {
            FantasyUser = fantasyUser;
        }
    }
}
