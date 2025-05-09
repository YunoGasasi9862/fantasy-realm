using App.FantasyUser.Authorization.Common;


namespace App.FantasyUser.Authorization.FantasyRealmAccessToken.Create
{
    public class FantasyUserAccessTokenResponse: TokenResponse
    {
        public FantasyUserAccessTokenResponse(bool isSuccessful, string? message, int id = 0) : base(isSuccessful, message, id)
        {
           
        }
    }
}
