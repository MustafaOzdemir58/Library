using Library.Entities.MessageBrokers.RabbitMQ.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.MessageBrokers.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        Task SendBookInsertedMessage(BookCreatedMessageDto model);
    }
}
