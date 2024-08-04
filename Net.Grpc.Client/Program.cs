using Grpc.Net.Client;
using Net.Grpc.Protos;

Console.WriteLine("Start Client");

await Task.Delay(3000);

using var channel = GrpcChannel.ForAddress("https://localhost:7018");//7018//5266
var client = new Greeter.GreeterClient(channel);


for(int i = 0; i < 5; i++)
{
    await Task.Delay(1000);

    var reply = await client.SayHelloAsync(new HelloRequest { Name = $"Name {i}" });
    Console.WriteLine($"Ответ сервера: {reply.Message}");
}


Console.ReadKey();
