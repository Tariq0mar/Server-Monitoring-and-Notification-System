using RabbitMQ.Client;
using ServerStatisticsCollectionService.Interfaces;
using ServerStatisticsCollectionService.StatisticsCalculators;
using System.Text;
using System.Text.Json;

namespace ServerStatisticsCollectionService.Message_Queue;

public class RabbitMQMessagePublisher : IMessagePublisher
{
    private readonly IServerStatisticsCalculator _calculator;

    public RabbitMQMessagePublisher(IServerStatisticsCalculator calculator)
    {
        _calculator = calculator;
    }

    public async Task<bool> PublishMessageAsync()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("product", exclusive: false);
            
            var statistics = _calculator.GetStatistics(); 
            var message = JsonSerializer.Serialize(statistics);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "ServerStatisticsExchange",
                routingKey: "ServerStatistics.Task1",
                basicProperties: null,
                body: body
            );

            return true;
        }
        catch
        {
            return false;
        }
    }

}