using Core.App.Domain;
using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMqProcessor
    {
        public Task<RabbitMqProcessorPackage> EstablishConnectionOnQueue(string queueName);
        public Task ProcessQueue<T>(IChannel channel, string queueName);
    }
}
