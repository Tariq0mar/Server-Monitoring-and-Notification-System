using ServerStatisticsCollectionService.StatisticsDTOs;

namespace ServerStatisticsCollectionService.Interfaces;

public interface IServerStatisticsCalculator
{
    public ServerStatistics GetStatistics();
}