using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Question.Create
{
    public class QuestionCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required, Length(5, 250)]
        public string Verbiage {  get; set; }

    }
}
