namespace ServerStatisticsCollectionService.StatisticsDTOs;

public class ServerStatistics
{
    public double MemoryUsage { get; set; }
    public double AvailableMemory { get; set; }
    public double CpuUsage { get; set; }
    public DateTime Timestamp { get; set; }

    public override string ToString()
    {
        return $"Time: {Timestamp}\n" +
               $"Memory Usage: {MemoryUsage} MB\n" +
               $"Available Memory: {AvailableMemory} MB\n" +
               $"CPU Usage: {CpuUsage} %";
    }
}