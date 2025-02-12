using App.FantasyRealm.Domain;
using App.FantasyRealm.Interfaces;
using Core.App.Features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
