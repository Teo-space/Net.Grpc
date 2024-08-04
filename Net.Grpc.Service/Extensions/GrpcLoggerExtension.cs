using Grpc.Core;
using System.Text.Json;

public static class GrpcLoggerExtension
{
    private readonly static JsonSerializerOptions WriteIndented = new JsonSerializerOptions { WriteIndented = true };

    public static void LogRequest<TService, TRequest, TResponse>(this ILogger<TService> logger,
        ServerCallContext context,
        TRequest request, TResponse response)
        where TService : class
        where TRequest : class
        where TResponse : class
    {
        logger.LogInformation($@"[{typeof(TService).Namespace}.{typeof(TService).Name}]
* Host: {context.Host}
* Peer: {context.Peer}
* Method: {context.Method}
* Request:
{(request != null ? JsonSerializer.Serialize(request, WriteIndented) : "'null'")}
* Response:
{(response != null ? JsonSerializer.Serialize(response, WriteIndented) : "'null'")}
");
    }
}
