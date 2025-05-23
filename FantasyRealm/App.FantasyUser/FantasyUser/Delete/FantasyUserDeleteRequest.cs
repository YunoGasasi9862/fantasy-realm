﻿using Core.App.Features;
using MediatR;

namespace App.FantasyUser.FantasyUser.Delete
{
    public class FantasyUserDeleteRequest: CommandRequest, IRequest<CommandResponse>
    {
        //remove add properties if you want to, but for now adding the same ones
        public FantasyUserDeleteRequest() { }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfilePicturePath { get; set; }
    }
}
