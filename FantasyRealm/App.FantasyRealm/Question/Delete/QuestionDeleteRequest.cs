using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Question.Delete
{
    public class QuestionDeleteRequest: CommandRequest, IRequest<CommandResponse>
    {
        public string Verbiage { get; set; }
    }
}
