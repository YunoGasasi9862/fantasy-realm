using Core.App.Domain;
using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMqProcessor: IRabbitMqWorker
    {
        public Task ProcessQueue<T>(IChannel channel, string queueName);
    }
}
