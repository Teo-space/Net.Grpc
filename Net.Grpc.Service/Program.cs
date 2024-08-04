using Net.Grpc.Service.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddGrpc();
    builder.Logging.AddSerilog();
}
var app = builder.Build();
{
    app.MapGrpcService<GreeterService>();

    app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
}
app.Run();
