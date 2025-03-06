using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.FantasyUser.Delete
{
    public class FantasyUserDeleteRequest: CommandRequest, IRequest<CommandResponse>
    {
    }
}
