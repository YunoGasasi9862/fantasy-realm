using Core.App.Domain;
using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMq
    {
        public Task<IConnection> EstablishConnection(RabbitMq rabbitMqConfiguration);

        public Task DeprovisionConnection();

        public Task<IChannel> GenerateChannel(IConnection connection);

        public Task<QueueDeclareOk> GenerateQueue(IChannel channel, string queueName, bool durable, bool exclusive, bool autoDelete, bool passive, bool noWait, IDictionary<string, object?>? extraArguments = null, CancellationToken cancellationToken = default);

        public Task DiscardQueue(string queue);

        //Might need to create Message Related Classes that are universal
        //TO-DO
        public Task PublishMessage(string queue, object Message);
    }
}
