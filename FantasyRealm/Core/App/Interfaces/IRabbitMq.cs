namespace Core.App.Interfaces
{
    public interface IRabbitMq
    {
        public Task EstablishConnection();

        public Task DeprovisionConnection();

        public Task GenerateQueue(string queue);

        public Task DiscardQueue(string queue);

        //Might need to create Message Related Classes that are universal
        //TO-DO
        public Task PublishMessage(string queue, object Message);
    }
}
