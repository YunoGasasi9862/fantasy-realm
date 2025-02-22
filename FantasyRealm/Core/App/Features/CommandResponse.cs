using Core.App.Domain;
using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Features
{
    public class CommandResponse : Entity, ICommandResponse
    {
        public bool IsSuccessful { get; }

        public string? Message { get; }


        public CommandResponse() { }

        public CommandResponse(bool isSuccessful, string? message, int id = 0) : base(id)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
