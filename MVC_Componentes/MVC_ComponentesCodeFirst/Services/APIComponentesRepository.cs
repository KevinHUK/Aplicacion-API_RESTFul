
using System.Net.Http.Headers;
using Azure.Messaging.ServiceBus;
using MVC_ComponentesCodeFirst.Models;
using Newtonsoft.Json;



namespace MVC_ComponentesCodeFirst.Services;

public class APIComponentesRepository : IComponenteRepositorio
{

    HttpClient _httpClient = null;
    private const string urlBase = "https://tiendaordenadoreswebapi20230915115409.azurewebsites.net/api/Componentes";

    public APIComponentesRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
       
    }


    public List<Componente> All()
    {

        var callResponse = _httpClient.GetAsync(urlBase).Result;

        var response = callResponse.Content.ReadAsStringAsync().Result;
        var componentes = JsonConvert.DeserializeObject<List<Componente>>(response);
        return componentes;

    }


    public Componente? GetById(int Id)
    {
        var callResponse = _httpClient.GetAsync(urlBase + $"/{Id}").Result;

        var response = callResponse.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Componente>(response);
    }


    public  void Add(Componente componente)
    {
        var uri = urlBase;
        var myContent = JsonConvert.SerializeObject(componente);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var result = _httpClient.PostAsync(uri, byteContent).Result;
        //ServiceBusClient client = new ServiceBusClient(_configuration["BusConnection"]);
        //var sender = client.CreateSender(_configuration["QueueName"]);
        //ServiceBusMessage message = new ServiceBusMessage($"Creando {componente.Categoria} {componente.NumeroDeSerie}");
        //await sender.SendMessageAsync(message);
    }

    public void Update(Componente componente, int id)
    {

        var componenteSerializado = JsonConvert.SerializeObject(componente);
        var buffer = System.Text.Encoding.UTF8.GetBytes(componenteSerializado);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var callResponse = _httpClient.PutAsync(urlBase + $"{id}", byteContent).Result;
        if (!callResponse.IsSuccessStatusCode)
        {

            throw new Exception($"Error en la solicitud HTTPS: {callResponse.StatusCode}");
        }
    }

    public void Delete(int id)
    {


        var callResponse = _httpClient.DeleteAsync(urlBase + $"/{id}").Result;


    }
}