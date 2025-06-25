using Server_Statistics_Collection_Service.StatisticsDTOs;

namespace Server_Statistics_Collection_Service.Interfaces;

public interface IServerStatisticsCalculation
{
    public ServerStatistics GetStatistics();
}