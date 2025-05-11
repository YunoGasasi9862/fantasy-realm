using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.PersonalityAnswer.Update
{
    public class PersonalityAnswerUpdateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int PersonalityTypeId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int ChoiceId { get; set; }

        public static Domain.PersonalityAnswer Copy(PersonalityAnswerUpdateRequest request, Domain.PersonalityAnswer personalityAnswer)
        {
            personalityAnswer.QuestionId = request.QuestionId;
            personalityAnswer.PersonalityTypeId = request.PersonalityTypeId;
            personalityAnswer.ChoiceId = request.ChoiceId;
            personalityAnswer.Id = request.Id;

            return personalityAnswer;
        }

        public override string ToString()
        {
            return $"Id: {Id}, QuestionId: {QuestionId}, PersonalityTypeId: {PersonalityTypeId}, ChoiceId: {ChoiceId}";
        }
    }
}
