

namespace App.FantasyUser.Domain
{
    public class AccessTokenSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationInMinutes { get; set; }

        public string EncryptedSecurityKey { get; set; }

        public int RefreshTokenExpirationTimeInDays { get; set; }
    }
}