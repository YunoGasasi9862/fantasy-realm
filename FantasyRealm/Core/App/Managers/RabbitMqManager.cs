using Core.App.Interfaces;
using RabbitMQ.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Core.App.Domain;
using System.Diagnostics;

namespace Core.App.Managers
{
    public class RabbitMqManager : IRabbitMq
    {
        //use cloudAMQP for connecting etc
        protected IConnection? Connection { get; set; }
        protected IChannel? Channel { get; set; }   
        protected RabbitMq? RabbitMqConfiguration { get; set; }

        public RabbitMqManager(IOptions<RabbitMq> rabbitMqConfiguration)
        {
            //get connection values from app.settings or any other settings file
            //use RabbitMqConfig model
            RabbitMqConfiguration = rabbitMqConfiguration.Value;

        }
        public Task DeprovisionConnection()
        {
            throw new NotImplementedException();
        }

        public Task DiscardQueue(string queue)
        {
            throw new NotImplementedException();
        }

        public async Task<IConnection> EstablishConnection(RabbitMq rabbitMqConfiguration)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                UserName = rabbitMqConfiguration.Username,
                HostName = rabbitMqConfiguration.HostName,
                Password = rabbitMqConfiguration.Password,
            };

            return await connectionFactory.CreateConnectionAsync();
        }

        //use QueueConfiguration here
        public async Task<QueueDeclareOk> GenerateQueue(IChannel channel, string queueName, bool durable, bool exclusive, bool autoDelete, bool passive, bool noWait, IDictionary<string, object?>? extraArguments = null, CancellationToken cancellationToken = default)
        {
            try
            {
                return await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: extraArguments, passive: passive, noWait: noWait, cancellationToken: cancellationToken);

            }catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

                throw new ApplicationException($"Exception Occured: {ex.Message}");
            }
        }

        public async Task<IChannel> GenerateChannel(IConnection connection)
        {
           return await connection.CreateChannelAsync();
        }

        public Task PublishMessage(string queue, object Message)
        {
            throw new NotImplementedException();
        }
    }
}
