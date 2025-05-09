using App.FantasyUser.Authorization.Common;

namespace App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create
{
    public class FantasyUserRefreshTokenResponse: TokenResponse
    {
        public FantasyUserRefreshTokenResponse(bool isSuccessful, string? message, int id = 0) : base(isSuccessful, message, id)
        {

        }
    }
}
