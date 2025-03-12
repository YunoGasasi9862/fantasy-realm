using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.QuestionChoice.Delete
{
    public class QuestionChoiceDeleteRequest : CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int QuestionId { get; set; }

        [Required, StringLength(125)]
        public string Choice { get; set; }
    }
}
