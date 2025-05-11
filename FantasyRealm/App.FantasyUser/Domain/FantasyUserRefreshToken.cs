

using Core.App.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.FantasyUser.Domain
{
    public class FantasyUserRefreshToken : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpirationTime { get; set; }

        public virtual FantasyUser FantasyUser { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, RefreshToken: {RefreshToken}, " +
                   $"Expires: {RefreshTokenExpirationTime}, " +
                   $"FantasyUser: {(FantasyUser != null ? FantasyUser.ToString() : "null")}";
        }
    }
}
