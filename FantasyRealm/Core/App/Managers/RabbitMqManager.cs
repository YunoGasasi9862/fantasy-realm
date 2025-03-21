using Core.App.Interfaces;
using RabbitMQ.Client;
using Newtonsoft.Json;
using Core.App.Domain;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client.Exceptions;

namespace Core.App.Managers
{
    public class RabbitMqManager : IRabbitMq
    {
        public RabbitMqManager()
        {

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

        public async Task<IConnection> EstablishConnection(RabbitMqConfiguration rabbitMqConfiguration)
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

        public async Task<QueueDeclareOk> CreateQueue(IChannel channel, QueueConfiguration queueConfiguration)
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

        public async Task<IChannel> CreateChannel(IConnection connection)
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

        public async Task<QueueDeclareOk?> GetQueueIfExists(IChannel channel, string queueName)
        {
            try
            {
                //checks if a queue exist if so returns it
                return await channel.QueueDeclarePassiveAsync(queueName);

            }catch (OperationInterruptedException ex)
            {
                return null;
            }
        }
    }
}
