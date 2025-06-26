using Server_Statistics_Collection_Service.Message_Queue;
using Server_Statistics_Collection_Service.StatisticsCalculators;

var serverStatisticsCalculator = new ServerStatisticsCalculator();

var publish = new RabbitMQMessagePublisher(serverStatisticsCalculator);
