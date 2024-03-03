using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MessageBrokers.RabbitMQ.Dtos
{
    public sealed class BookCreatedMessageDto
    {
        public string BookName { get; set; }
        public DateTime BookCreatedDate { get; set; }
    }
}
