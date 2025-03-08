using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Managers
{
    public class RabbitMqManager : IRabbitMq
    {
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
