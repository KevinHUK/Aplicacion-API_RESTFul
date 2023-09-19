using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using MVC_ComponentesCodeFirst.Models;
using Newtonsoft.Json;

namespace MVC_ComponentesCodeFirst.Services;

public interface IServiceBus
{
   
        Task SendMessageAsync(Componente componenteDetails);
    
}
