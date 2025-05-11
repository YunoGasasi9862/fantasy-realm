using Core.App.Features;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.PersonalityAnswer.Query
{
    public class PersonalityAnswerQueryResponse : QueryResponse
    {
        [Required]
        public int PersonalityTypeId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public int ChoiceId { get; set; }
    }
}
 