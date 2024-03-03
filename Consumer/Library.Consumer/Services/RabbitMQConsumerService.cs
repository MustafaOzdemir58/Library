using Library.Consumer.Extensions;
using Library.Consumer.Models.Dtos;
using Library.Consumer.Models.Json;
using Library.Consumer.Models.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Library.Consumer.Services
{
    public sealed class RabbitMQConsumerService
    {
        private static readonly string mainDirectory = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf(@"\bin"));
        public static void GetBookCreatedMessage(RabbitMQSettings settings)
        {
            try
            {
                string queueName = "book-inserted";
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(settings.ConnectionUrl, UriKind.RelativeOrAbsolute)
                };
                var connection = factory.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    //channel.QueueDeclare(queueName, exclusive: false);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += Consumer_Received;
                    channel.BasicConsume(queueName, autoAck: true, consumer);

                }
            }
            catch (Exception ex)
            {


            }
        }

        private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            try
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var resposeModel = JsonSerializer.Deserialize<BookCreatedMessageConsumerDto>(message);
                if (resposeModel != null)
                {
                    var jsonLogFile = Path.Combine(mainDirectory, "json", "created-books-logs.json");
                    if (!File.Exists(jsonLogFile))
                    {
                        File.Create(jsonLogFile).Close();
                        File.WriteAllText(jsonLogFile, JsonSerializer.Serialize(new List<CreatedBookLogJson>()));
                    }

                    var currentLogs = JsonSerializer.Deserialize<List<CreatedBookLogJson>>(File.ReadAllText(jsonLogFile));
                    currentLogs.Add(resposeModel.ConvertToCreatedLogJsonModel());
                    var updatedJson = JsonSerializer.Serialize(currentLogs);
                    File.WriteAllText(jsonLogFile, updatedJson);
                }
            }


            catch (Exception ex)
            {


            }

        }
    }
}
