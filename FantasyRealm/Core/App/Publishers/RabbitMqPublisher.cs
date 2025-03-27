using Core.App.Domain;
using Core.App.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Diagnostics;

namespace Core.App.Publishers
{
    public class RabbitMqPublisher: IRabbitMqPublisher
    {
        private IRabbitMq RabbitMqManager { get; set; }
        private RabbitMqConfiguration RabbitMqConfiguration { get; set; }
        private QueueConfiguration QueueConfiguration { get; set; }

        public RabbitMqPublisher(IRabbitMq rabbitMq, IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            RabbitMqManager = rabbitMq;

            RabbitMqConfiguration = rabbitMqConfiguration.Value;

            QueueConfiguration = new QueueConfiguration();
        }

        public Task PublishMessage<T>(IChannel channel, string queueName)
        {
            throw new NotImplementedException();
        }
    }
}
