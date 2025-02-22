﻿using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyRealm.PersonalityType.Create
{
    public class PersonalityTypeCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(125)]
        public string Description { get; set; }
    }
}
