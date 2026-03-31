using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentService.Application.Dispatchers;

public class EventDispatcher(IServiceScopeFactory scopeFactory) : IEventDispatcher
{
    public async Task Dispatch(string topic, string json)
    {
        try
        {
            using var scope = scopeFactory.CreateScope();

            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("eventType", out var typeElement))
            {
                Console.WriteLine("No type found in Json");
            }

            string type = typeElement.GetString();

            if (topic == "booking" && type == "Created")
            {
                Console.WriteLine("hejhej -----");
            }
            else if (topic == "workshop")
            {
                Console.WriteLine("Should call workshop handlers");
            }
            else
            {
                Console.WriteLine("NOOOOOOO topic ahh");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"General Error: {e.Message}");
        }
    }
}