using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Domain
{
    public class RabbitMqDataPackage
    {
        public IConnection? Connection { get; set; }
        public IChannel? Channel { get; set; }
        public QueueDeclareOk? QueueDeclareOk { get; set; }
    }
}
