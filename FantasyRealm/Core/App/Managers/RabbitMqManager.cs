using Core.App.Interfaces;
using RabbitMQ.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Core.App.Domain;
using System.Diagnostics;
using System.Text;

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
        public async Task DeprovisionConnection(IConnection connection)
        {
            if (connection.IsOpen)
            {
                await connection.CloseAsync();

                connection.Dispose();
            }
        }

        public async Task PurgeQueue(IChannel channel, string queueName)
        {
            await channel.QueuePurgeAsync(queueName);
        }

        public async Task<IConnection> EstablishConnection(RabbitMq rabbitMqConfiguration)
        {
            try
            {
                ConnectionFactory connectionFactory = new ConnectionFactory
                {
                    UserName = rabbitMqConfiguration.Username,
                    HostName = rabbitMqConfiguration.HostName,
                    Password = rabbitMqConfiguration.Password,
                };

                return await connectionFactory.CreateConnectionAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

                throw new ApplicationException($"Exception Occured: {ex.Message}");
            }

        }

        public async Task<QueueDeclareOk> GenerateQueue(IChannel channel, QueueConfiguration queueConfiguration)
        {
            try
            {
                return await channel.QueueDeclareAsync(queue: queueConfiguration.QueueName, durable: queueConfiguration.Durable, 
                    exclusive: queueConfiguration.Exclusive, autoDelete: queueConfiguration.AutoDelete, arguments: queueConfiguration.ExtraArguments, 
                    passive: queueConfiguration.Passive, noWait: queueConfiguration.NoWait, cancellationToken: queueConfiguration.CancellationToken);

            }catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

                throw new ApplicationException($"Exception Occured: {ex.Message}");
            }
        }

        public async Task<IChannel> GenerateChannel(IConnection connection)
        {
            try
            {
                return await connection.CreateChannelAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

                throw new ApplicationException($"Failed to Create the channel: {ex.Message}");
            }
        }
        public async Task RemoveQueue(IChannel channel, string queueName)
        {
            await channel.QueueDeleteAsync(queueName);
        }
        
        public async Task PublishMessage<T>(IChannel channel, string queue, T message, CancellationToken cancellationToken)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
               await channel.BasicPublishAsync(
                        exchange: string.Empty, //default
                        routingKey: queue,
                        mandatory: true,
                        body : messageBytes,
                        cancellationToken: cancellationToken

                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

                throw new ApplicationException($"Failed to Publish the Message: {ex.Message}");
            }
        }

    }
}
