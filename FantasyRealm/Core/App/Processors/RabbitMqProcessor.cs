using Core.App.Domain;
using Core.App.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Core.App.Processors
{
    public class RabbitMqProcessor : IRabbitMqProcessor
    {
        private IRabbitMq RabbitMqManager { get; set; }
        private RabbitMqConfiguration RabbitMqConfiguration { get; set; }
        private QueueConfiguration QueueConfiguration { get; set; }

        public RabbitMqProcessor(IRabbitMq rabbitMq, IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            RabbitMqManager = rabbitMq;

            RabbitMqConfiguration = rabbitMqConfiguration.Value;

            QueueConfiguration = new QueueConfiguration();

        }

        public async Task<RabbitMqProcessorPackage> EstablishConnectionOnQueue(string queueName)
        {
            return await RabbitMqManager.EstablishConnectionOnQueue(RabbitMqConfiguration, QueueConfiguration, queueName);
        }

        //will run indefinitely - that's how rabbitMq's consumer architecture is
        //here T is the DataType

        public async Task ProcessQueue<T>(IChannel channel, string queueName)
        {
            AsyncEventingBasicConsumer asyncEventingBasicConsumer = new AsyncEventingBasicConsumer(channel);

            //registers an event handler - ReceiveData. Sender is the consumer, and the basicDeveliverEventArgs has delivery tag etc

            asyncEventingBasicConsumer.ReceivedAsync += async (sender, basicDeliverEventArgs) => await ReceiveData<T>(channel, basicDeliverEventArgs);

            await channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer: asyncEventingBasicConsumer);
        }

        private async Task ReceiveData<T>(IChannel channel, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            try
            {
                string dataInString = Encoding.UTF8.GetString(basicDeliverEventArgs.Body.ToArray());

                T? castedData = JsonSerializer.Deserialize<T>(dataInString);

                await channel.BasicAckAsync(basicDeliverEventArgs.DeliveryTag, false);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception Occured: {ex.Message}");
                throw;
            }

        }
    }
}
