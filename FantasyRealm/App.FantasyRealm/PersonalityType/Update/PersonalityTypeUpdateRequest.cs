using Core.App.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FantasyRealm.PersonalityType.Update
{
    public class PersonalityTypeUpdateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required, StringLength(125)]
        public string Name { get; set; }

        [Required, StringLength(1000)]
        public string Description { get; set; }

        public static Domain.PersonalityType Copy(PersonalityTypeUpdateRequest personalityTypeUpdateRequest, Domain.PersonalityType personalityType)
        {
            personalityType.Description = personalityTypeUpdateRequest.Description.Trim();
            personalityType.Name = personalityTypeUpdateRequest.Name.Trim();
            personalityType.Id = personalityTypeUpdateRequest.Id;

            return personalityType;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}";
        }
    }
}
