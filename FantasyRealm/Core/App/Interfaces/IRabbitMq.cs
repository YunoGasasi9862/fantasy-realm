using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    internal interface IRabbitMq
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
