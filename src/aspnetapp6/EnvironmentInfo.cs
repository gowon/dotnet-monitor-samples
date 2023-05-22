using System.Net;
using System.Runtime.InteropServices;

namespace aspnetapp6;

public struct EnvironmentInfo
{
    public EnvironmentInfo()
    {
        var gcInfo = GC.GetGCMemoryInfo();
        TotalAvailableMemoryBytes = gcInfo.TotalAvailableMemoryBytes;

        if (!OperatingSystem.IsLinux()) return;

        string[] memoryLimitPaths =
        {
            "/sys/fs/cgroup/memory.max",
            "/sys/fs/cgroup/memory.high",
            "/sys/fs/cgroup/memory.low",
            "/sys/fs/cgroup/memory/memory.limit_in_bytes"
        };

        string[] currentMemoryPaths =
        {
            "/sys/fs/cgroup/memory.current",
            "/sys/fs/cgroup/memory/memory.usage_in_bytes"
        };

        MemoryLimit = GetBestValue(memoryLimitPaths);
        MemoryUsage = GetBestValue(currentMemoryPaths);
    }

    public string RuntimeVersion => RuntimeInformation.FrameworkDescription;
    public string OSVersion => RuntimeInformation.OSDescription;
    public string OSArchitecture => RuntimeInformation.OSArchitecture.ToString();
    public string User => Environment.UserName;
    public int ProcessorCount => Environment.ProcessorCount;
    public long TotalAvailableMemoryBytes { get; }
    public long MemoryLimit { get; }
    public long MemoryUsage { get; }
    public string HostName => Dns.GetHostName();

    private static long GetBestValue(string[] paths)
    {
        foreach (var path in paths)
            if ((File.Exists(path) || Directory.Exists(path)) &&
                long.TryParse(File.ReadAllText(path), out var result))
                return result;

        return 0;
    }
}