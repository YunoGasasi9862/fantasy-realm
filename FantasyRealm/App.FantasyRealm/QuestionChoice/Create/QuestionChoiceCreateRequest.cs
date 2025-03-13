using Core.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.QuestionChoice.Create
{
    public class QuestionChoiceCreateRequest
    {
        [Required]
        public int QuestionId { get; set; }

        [Required, StringLength(125)]
        public string Choice { get; set; }
    }
}
