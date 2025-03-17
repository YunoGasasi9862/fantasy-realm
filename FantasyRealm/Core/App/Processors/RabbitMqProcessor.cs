using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Processors
{
    public class RabbitMqProcessor : IRabbitMqProcessor
    {
        public Task EstablishConnectionOnQueue()
        {
            throw new NotImplementedException();
        }

        public Task ProcessQueue(string QueueName)
        {
            throw new NotImplementedException();
        }
    }
}
