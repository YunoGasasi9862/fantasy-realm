using Core.App.Features;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.QuestionChoice.Query
{
    public class QuestionChoiceQueryResponse : QueryResponse
    {
        [Required]
        public int QuestionId { get; set; }

        [Required, StringLength(125)]
        public string Choice { get; set; }
    }
}
