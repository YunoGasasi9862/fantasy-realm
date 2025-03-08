using App.FantasyRealm.PersonalityType.Update;
using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.Question.Update
{
    public class QuestionUpdateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required, Length(5, 250)]
        public string Verbiage { get; set; }

        public static Domain.Question Copy(QuestionUpdateRequest questionUpdateRequest, Domain.Question question)
        {
            question.Verbiage = questionUpdateRequest.Verbiage.Trim();
            question.Id = questionUpdateRequest.Id;

            return question;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Question: {Verbiage}";
        }
    }
}
