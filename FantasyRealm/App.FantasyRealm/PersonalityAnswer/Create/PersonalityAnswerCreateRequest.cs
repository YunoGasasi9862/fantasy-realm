using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.PersonalityAnswer.Create
{
    public class PersonalityAnswerCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int PersonalityTypeId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int ChoiceId { get; set; }
    }
}
