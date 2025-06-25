using Server_Statistics_Collection_Service.Interfaces;
using Server_Statistics_Collection_Service.StatisticsDTOs;
using System.Diagnostics;

namespace Server_Statistics_Collection_Service.StatisticsCalculators;

public class ServerStatisticsCalculator : IServerStatisticsCalculation
{
    public ServerStatistics GetStatistics()
    {
        // source "https://www.c-sharpcorner.com/uploadfile/puranindia/performancecounter-in-C-Sharp/"

        var cpu = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
        var cpuUsage = cpu.NextValue();

        var memory = new PerformanceCounter("Memory", "Available MBytes");
        var availableMemory = memory.NextValue();

        var currentProcess = Process.GetCurrentProcess();
        var memoryUsageB = currentProcess.PrivateMemorySize64;
        var memoryUsageMB = memoryUsageB / (1024.0 * 1024.0);

        return new ServerStatistics
        {
            CpuUsage = cpuUsage,
            AvailableMemory = availableMemory,
            MemoryUsage = memoryUsageMB,
            Timestamp = DateTime.UtcNow
        };
    }
}