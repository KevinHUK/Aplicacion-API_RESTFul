using MVC_ComponentesCodeFirst.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVC_ComponentesCodeFirst.Services;

public class APIOrdenadorRepository : IRepositorioOrdenador
{
	HttpClient _httpClient = null;
    private const string urlBase = "https://tiendaordenadoreswebapi20230915115409.azurewebsites.net/api/Ordenadores";
    public APIOrdenadorRepository(HttpClient httpClient)
	{
        _httpClient = httpClient;

	}
	public Ordenador? GetOrdenador(int Id)
	{
        var callResponse = _httpClient.GetAsync(urlBase + $"/{Id}").Result;

        var response = callResponse.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Ordenador>(response);
    }

	public decimal? GetPrecioTotal(int Id)
	{
		throw new NotImplementedException();
	}

	public int? GetCalorTotal(int Id)
	{
		throw new NotImplementedException();
	}

	public void DeleteOrdenador(int Id)
	{
		throw new NotImplementedException();
	}

	public void Update(Ordenador? ordenador, int id)
	{
		throw new NotImplementedException();
	}

	public void AddOrdenador(Ordenador ordenador)
	{
        var uri = urlBase;

        var myContent = JsonConvert.SerializeObject(ordenador);
		var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
		var byteContent = new ByteArrayContent(buffer);
		byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		var result = _httpClient.PostAsync(uri, byteContent).Result;

	}

	public List<Ordenador>? GetOrdenadorList()
	{
		var callResponse = _httpClient.GetAsync(urlBase).Result;

		var response = callResponse.Content.ReadAsStringAsync().Result;
		var ordenadores = JsonConvert.DeserializeObject<List<Ordenador>>(response);
		return ordenadores;
	}


}