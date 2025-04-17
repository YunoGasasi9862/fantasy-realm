using App.FantasyRealm.Domain;
using Core.Interfaces;
using Core.App.Features;
using System.Globalization;

namespace App.FantasyRealm.Features
{
    public class FantasyRealmDBHandler : Handler, IDBHandler
    {
        protected readonly FantasyRealmDBContext fantasyRealmDBContext;
        public FantasyRealmDBHandler(FantasyRealmDBContext fantasyRealmDBContext) : base(new CultureInfo("en-US"))
        {
            this.fantasyRealmDBContext = fantasyRealmDBContext;
        }
    }
}
