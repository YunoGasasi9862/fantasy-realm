using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMqPublisher: IRabbitMqWorker
    {
        public Task PublishMessage<T>(IChannel channel, string queueName, T data, CancellationToken cancellationToken);
    }
}
