using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Domain
{
    public class RabbitMq
    {
        public RabbitMq() { }
        public string HostName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
