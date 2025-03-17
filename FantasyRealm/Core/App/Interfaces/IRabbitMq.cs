﻿using Core.App.Domain;
using RabbitMQ.Client;

namespace Core.App.Interfaces
{
    public interface IRabbitMq
    {
        public Task<IConnection> EstablishConnection(RabbitMq rabbitMqConfiguration);

        public Task DeprovisionConnection(IConnection connection);

        public Task<IChannel> CreateChannel(IConnection connection);

        public Task<QueueDeclareOk> CreateQueue(IChannel channel, QueueConfiguration queueConfiguration);

        public Task PurgeQueue(IChannel channel, string queueName);

        public Task RemoveQueue(IChannel channel, string queueName);

        public Task PublishMessage<T>(IChannel channel, string queue, T message, CancellationToken cancellationToken);
    }
}
