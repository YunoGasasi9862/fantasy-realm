using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Features
{
    public class Handler : IHandler
    {
        protected Handler(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public ICommandResponse Error(string message)
        {
            return new CommandResponse(false, message);
        }

        public ICommandResponse Success(string message, int id)
        {
            return new CommandResponse(true, message, id);
        }
    }
}
