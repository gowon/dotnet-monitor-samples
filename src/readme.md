# dotnet-monitor and Sample ASP.NET Core Applications

`dotne-monitor` is a tool that allows you to gather diagnostic data from running applications using HTTP endpoints.

## Containers

|Container|Purpose|Image|
|-|-|-|
|.NET Samples|Sample ASP.NET Core application|[`mcr.microsoft.com/dotnet/samples:aspnetapp`](https://mcr.microsoft.com/en-us/product/dotnet/samples/about)|
|`aspnetapp6`|Sample ASP.NET Core application|Based on <https://github.com/dotnet/dotnet-docker/tree/main/samples/aspnetapp>|
|`aspnetapp7`|Sample ASP.NET Core application|Based on <https://github.com/dotnet/dotnet-docker/tree/main/samples/aspnetapp>|
|.NET Monitor|Diagnostics|[`mcr.microsoft.com/dotnet/monitor:7`](https://mcr.microsoft.com/en-us/product/dotnet/monitor/about)|

## Demo

```powershell
# To spin up all containers run:
## .NET 6.0 example
docker compose --project-name monitor6 --profile net60 up -d

## .NET 7.0 example
docker compose --project-name monitor7 --profile net70 up -d

# To spin down all containers run:
docker compose down

# To delete all data run:
docker compose down -v
```
