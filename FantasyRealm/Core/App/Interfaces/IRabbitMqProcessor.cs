using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Interfaces
{
    public interface IRabbitMqProcessor
    {
        public Task EstablishConnectionOnQueue(string queueName);
        public Task ProcessQueue(string queueName);
    }
}
