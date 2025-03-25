using Core.App.Domain;
using Core.App.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Diagnostics;

namespace Core.App.Processors
{
    public class RabbitMqProcessor : IRabbitMqProcessor
    {
        //use cloudAMQP for connecting etc
        private IConnection? Connection { get; set; }
        private IChannel? Channel { get; set; }
        private IRabbitMq RabbitMqManager { get; set; }
        private RabbitMqConfiguration RabbitMqConfiguration { get; set; }

        private QueueConfiguration QueueConfiguration { get; set; }

        public RabbitMqProcessor(IRabbitMq rabbitMq, IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            RabbitMqManager = rabbitMq;
            RabbitMqConfiguration = rabbitMqConfiguration.Value;

            //declare a default instance with default values
            QueueConfiguration = new QueueConfiguration();
        }

        public async Task EstablishConnectionOnQueue(string queueName)
        {
            try
            {
                //check what might be happening here!
                Connection = await RabbitMqManager.EstablishConnection(RabbitMqConfiguration);

                Channel = await RabbitMqManager.CreateChannel(Connection);

                //update queueName
                QueueConfiguration.UpdateQueueName(queueName);

                QueueDeclareOk queueDeclareOk = await RabbitMqManager.GetQueueIfExists(Connection, queueName) ?? await RabbitMqManager.CreateQueue(Channel, QueueConfiguration);

            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }
        }

        public Task ProcessQueue(string QueueName)
        {
            throw new NotImplementedException();
        }
    }
}
