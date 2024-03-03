// See https://aka.ms/new-console-template for more information
using Library.Consumer.Models.Settings;
using Library.Consumer.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text.Json;

var builder = new ConfigurationBuilder();
var mainDirectory = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf(@"\bin"));
builder.SetBasePath(mainDirectory)
       .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true);


IConfiguration config = builder.Build();
var settings = config.GetRequiredSection("RabbitMQSettings").Get<RabbitMQSettings>();
check:
RabbitMQConsumerService.GetBookCreatedMessage(settings);
Console.WriteLine("Event completed.");
Console.Write("Check again ? (Y/N)");
var state = Console.ReadLine();
if (state=="Y")
{
    goto check;
}
Console.ReadKey();