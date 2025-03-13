using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.QuestionChoice.Update
{
    public class QuestionChoiceUpdateRequest : CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        public int QuestionId { get; set; }

        [Required, StringLength(125)]
        public string Choice { get; set; }

        public static Domain.QuestionChoice Copy(QuestionChoiceUpdateRequest questionChoiceUpdateRequest, Domain.QuestionChoice questionChoice)
        {
            questionChoice.Choice = questionChoiceUpdateRequest.Choice.Trim();
            questionChoice.QuestionId = questionChoiceUpdateRequest.QuestionId;

            return questionChoice;
        }

        public override string ToString()
        {
            return $"Choice: {Choice}, QuestionId: {QuestionId}";
        }
    }
}
