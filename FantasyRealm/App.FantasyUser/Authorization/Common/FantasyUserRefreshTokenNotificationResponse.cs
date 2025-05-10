

namespace App.FantasyUser.Authorization.Common
{
    public class FantasyUserRefreshTokenNotificationResponse
    {
        public string RefreshToken { get; set; }

        public FantasyUserRefreshTokenNotificationResponse() { }

        public FantasyUserRefreshTokenNotificationResponse(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
