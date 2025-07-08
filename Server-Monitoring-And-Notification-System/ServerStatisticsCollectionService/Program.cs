using ServerStatisticsCollectionService.Message_Queue;
using ServerStatisticsCollectionService.StatisticsCalculators;

var serverStatisticsCalculator = new ServerStatisticsCalculator();

var publish = new RabbitMQMessagePublisher(serverStatisticsCalculator);