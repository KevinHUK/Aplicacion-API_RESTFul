using System.Text.Json;
using System.Text;
using Microsoft.Azure.ServiceBus;
using TiendaOrdenadoresWebApi.Models;


namespace TiendaOrdenadoresWebApi.Services;

public class ServiceBus : IServiceBus
{
    private readonly IConfiguration _configuration;
    public ServiceBus(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task SendMessageAsync(Componente componenteDetails)
    {
        IQueueClient client = new QueueClient(_configuration["AzureServiceBusConnectionString"], _configuration["QueueName"]);
        //Serialize car details object
        var messageBody = JsonSerializer.Serialize(componenteDetails);
        //Set content type and Guid
        var message = new Message(Encoding.UTF8.GetBytes(messageBody))
        {
            MessageId = Guid.NewGuid().ToString(),
            ContentType = "application/json"
        };
        await client.SendAsync(message);
    }
}