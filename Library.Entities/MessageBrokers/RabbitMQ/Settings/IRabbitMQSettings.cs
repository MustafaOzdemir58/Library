using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MessageBrokers.RabbitMQ.Settings
{
    public interface IRabbitMQSettings
    {
       
        string ConnectionUrl { get; set; }
    }
}
