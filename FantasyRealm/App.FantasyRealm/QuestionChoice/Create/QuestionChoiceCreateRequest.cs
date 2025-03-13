using Core.App.Domain;
using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.QuestionChoice.Create
{
    public class QuestionChoiceCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int QuestionId { get; set; }

        [Required, StringLength(125)]
        public string Choice { get; set; }
    }
}
