

using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App.FantasyUser.Domain
{
    public class AccessTokenSettings
    {
        public AccessTokenSettings() { }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationInMinutes { get; set; }

        public string EncryptedSecurityKey { get; set; }

        public SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(EncryptedSecurityKey));

        public int RefreshTokenExpirationTimeInDays { get; set; }

        public int RefreshTokenLengthInBytes { get; set; }
    }
}