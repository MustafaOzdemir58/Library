using Library.Entities.MessageBrokers.RabbitMQ.Dtos;
using Library.Entities.MessageBrokers.RabbitMQ.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Business.MessageBrokers.RabbitMQ
{
    public sealed class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IRabbitMQSettings _rabbitMQSettings;

        public RabbitMQProducer(IRabbitMQSettings rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }

        public async Task SendBookInsertedMessage(BookCreatedMessageDto model)
        {
            try
            {
                string queueName = "book-inserted";
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(_rabbitMQSettings.ConnectionUrl, UriKind.RelativeOrAbsolute),
                };
                var connection = factory.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, exclusive: false);
                    var json = JsonSerializer.Serialize(model);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
                }

            }
            catch (Exception)
            {


            }

        }
    }
}
