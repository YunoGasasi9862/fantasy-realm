using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Domain
{
    public class QueueConfiguration
    {
        public QueueConfiguration() { }
        public string QueueName { get; set; } = "defaultQueue"; //this needs to be changed/updated whenever we pass QueueConfiguration
        public bool Durable { get; set; } = true;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = false;
        public bool Passive { get; set; } = false;
        public bool NoWait { get; set; } = false;
        public IDictionary<string, object?>? ExtraArguments { get; set; } = null;
        public CancellationToken CancellationToken { get; set; } = new CancellationTokenSource().Token;

        public void UpdateQueueName(string queueName)
        {
            QueueName = queueName;
        }

        public override string ToString()
        {
            return $"QueueConfiguratin: QueueName - {QueueName} Durable - {Durable} Exclusive - {Exclusive} AutoDelete - {AutoDelete} Passive {Passive} NoWait {NoWait} ExtraArguments {ExtraArguments} CancellationToken {CancellationToken}";
        }
    }
}
