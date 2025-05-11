using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.PersonalityAnswer.Delete
{
    public class PersonalityAnswerDeleteRequest:  CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int PersonalityTypeId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int ChoiceId { get; set; }
    }
}
