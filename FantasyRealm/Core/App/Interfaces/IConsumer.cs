using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    public interface IConsumer
    {
        public Task ConsumeMessage<T>(IChannel channel, string queueName, CancellationToken cancellationToken);
    }
}
