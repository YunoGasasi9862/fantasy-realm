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
        public string QueueName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public bool Passive { get; set; }
        public bool NoWait { get; set; }
        public IDictionary<string, object?>? ExtraArguments { get; set; } = null;
        public CancellationToken CancellationToken { get; set; } = new CancellationTokenSource().Token;
    }
}
