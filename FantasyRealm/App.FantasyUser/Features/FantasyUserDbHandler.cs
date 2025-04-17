using App.FantasyUser.Domain;
using Core.App.Features;
using Core.Interfaces;
using System.Globalization;

namespace App.FantasyUser.Features
{
    public class FantasyUserDbHandler: Handler, IDBHandler
    {
        protected readonly FantasyUserDbContext fantasyUserDbContext;

        public FantasyUserDbHandler(FantasyUserDbContext fantasyUserDbContext) : base(new CultureInfo("en-US"))
        {
            this.fantasyUserDbContext = fantasyUserDbContext;
        }
    }
}
