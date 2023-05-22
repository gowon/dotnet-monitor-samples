# Dotnet Container Benchmarking

## Docker Configuration

An external docker network is used to bridge multiple separate docker instances for I/O.  Use the following commands in PowerShell to manage the networks used in this solution:

```powershell
# create external docker networks
docker network create monitor-shared

# delete external docker networks
docker network rm monitor-shared
```

## `dotnet-monitor` Sidecar Container

### Configuration

```powershell
dotnet-monitor config show
```

- <https://learn.microsoft.com/en-us/dotnet/core/runtime-config/debugging-profiling>
- <https://learn.microsoft.com/en-us/dotnet/core/diagnostics/available-counters>
- <https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/diagnostics?view=aspnetcore-7.0>

## Load Testing

### LoadTestToolbox

[LoadTestToolbox](https://github.com/ecoAPM/LoadTestToolbox) is a set of lightweight tools for load testing web applications.

```powershell
dotnet ltt drill --url http://localhost:<PORT>/ --rps 500 --duration 30 --filename .\artifacts\drill-chart.png

dotnet ltt hammer --url http://localhost:<PORT>/ --min 1 --max 100 --filename .\artifacts\hammer-chart.png

dotnet ltt nailgun --url http://localhost:<PORT>/ --requests 1000 --filename .\artifacts\nailgun-chart.png
```

## Visualization

### Unofficial `dotnet-monitor` UI

`dotnet-monitor UI` is easy to access user experience for `dotnet-monitor`. It is accessed by pointing the website <https://dotnet-monitor-ui.dev/> to your dotnet-monitor endpoint.

The following configuration needs to be added to your `dotnet-monitor` container:

```json
  "CorsConfiguration": {
    "AllowedOrigins": "https://dotnet-monitor-ui.dev"
  }
```

### Grafana

- <https://dotnetos.org/blog/2021-11-22-dotnet-monitor-grafana/>

## Garbage Collection

- <https://www.infoq.com/news/2022/11/GCCollectionMode-Aggressive/>

## References

- <https://github.com/dotnet/dotnet-monitor>
- <https://blog.steadycoding.com/asp-net-core-3-1-response-time-and-memory-spikes-in-kubernetes/>
- <https://learn.microsoft.com/en-us/events/dotnetconf-2020/collecting-aspnet-core-performance-traces-in-a-kubernetes-cluster>
- <https://github.com/ecoAPM/LoadTestToolbox>
