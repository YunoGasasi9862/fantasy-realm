using Core.App.Domain;
using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Features
{
    public abstract class CommandRequest : Entity, ICommandRequest
    {
        public CommandRequest() { }
    }
}
