using Core.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Managers
{
    public class TwoFactorAuthenticator : IAuthenticator
    {
        IRabbitMqProcessor RabbitMQProcessor { get; set; }
        public TwoFactorAuthenticator(IRabbitMqProcessor rabbitMqProcessor)
        {
            RabbitMQProcessor = rabbitMqProcessor;
        }
        public Task TwoFactorAuthentication(string email)
        {
            throw new NotImplementedException();
        }
    }
}
