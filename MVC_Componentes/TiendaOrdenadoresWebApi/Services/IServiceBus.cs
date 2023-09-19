using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.Services;

public interface IServiceBus
{
   
        Task SendMessageAsync(Componente componenteDetails);
    
}
