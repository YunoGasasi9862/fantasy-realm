using Core.App.Domain;
using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMq
    {
        public Task<IConnection> EstablishConnection(RabbitMq rabbitMqConfiguration);

        public Task DeprovisionConnection();

        public Task<IChannel> GenerateChannel(IConnection connection);

        public Task<QueueDeclareOk> GenerateQueue(IChannel channel, QueueConfiguration queueConfiguration);

        public Task PurgeQueue(IChannel channel, string queueName);

        public Task RemoveQueue(IChannel channel, string queueName);

        public Task PublishMessage<T>(IChannel channel, string queue, T message, CancellationToken cancellationToken);
    }
}
