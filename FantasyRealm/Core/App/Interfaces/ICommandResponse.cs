using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    public interface ICommandResponse
    {
        public bool IsSuccessful { get; }

        public string? Message { get; }
    }
}
