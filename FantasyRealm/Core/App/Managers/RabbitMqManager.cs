using Core.App.Interfaces;

namespace Core.App.Managers
{
    public class RabbitMqManager : IRabbitMq
    {
        public RabbitMqManager()
        { 
        
        }
        public Task DeprovisionConnection()
        {
            throw new NotImplementedException();
        }

        public Task DiscardQueue(string queue)
        {
            throw new NotImplementedException();
        }

        public Task EstablishConnection()
        {
            throw new NotImplementedException();
        }

        public Task GenerateQueue(string queue)
        {
            throw new NotImplementedException();
        }

        public Task PublishMessage(string queue, object Message)
        {
            throw new NotImplementedException();
        }
    }
}
