using RabbitMQ.Client;
using Server_Statistics_Collection_Service.Interfaces;
using Server_Statistics_Collection_Service.StatisticsCalculators;
using System.Text;
using System.Text.Json;

namespace Server_Statistics_Collection_Service.Message_Queue;

public class RabbitMQMessagePublisher : IMessagePublisher
{
    private readonly ServerStatisticsCalculator _calculator;

    public RabbitMQMessagePublisher(ServerStatisticsCalculator calculator)
    {
        _calculator = calculator;
    }

    public Task<bool> PublishMessage()
    {
        // source "https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/"
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnectionAsync();
            var channel = connection.CreateModel();
            
            channel.QueueDeclare("product", exclusive: false);

            var statistics = _calculator.GetStatistics();
            var message = JsonSerializer.Serialize(statistics);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "ServerStatisticsExchange", routingKey: "ServerStatistics.Task1", body: body);

            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }
}