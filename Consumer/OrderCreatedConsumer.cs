using MassTransit;
using SharedModels;
using System.Text.Json;

namespace Consumer;

public class OrderCreatedConsumer : IConsumer<IOrderCreated>
{
    public async Task Consume(ConsumeContext<IOrderCreated> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);

        Console.WriteLine($"Received message: {jsonMessage}");

        await Task.CompletedTask;
    }
}
