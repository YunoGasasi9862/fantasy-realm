

using Core.App.Domain;

namespace App.FantasyUser.Domain
{
    //remove this entity later, and configure in the DB context class to use UserId as primary key
    public class FantasyUserRefreshToken : Entity
    {
        //make 1:1
        public int UserId { get; set; }

        public string RefreshToken { get; set; }

        public int RefreshTokenExpirationTime { get; set; }
    }
}
