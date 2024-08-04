using Grpc.Core;
using Net.Grpc.Protos;

namespace Net.Grpc.Service.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var result = new HelloReply
        {
            Message = "Hello " + request.Name
        };

        _logger.LogRequest(context, request, result);

        return Task.FromResult(result);
    }

}

