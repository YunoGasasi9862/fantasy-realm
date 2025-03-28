using Core.App.Domain;

public interface IRabbitMqWorker
{
    public Task<RabbitMqDataPackage> EstablishConnectionOnQueue(string queueName);
}