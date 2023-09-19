using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Services;
using Polly;
using Polly.Extensions.Http;

namespace MVC_ComponentesCodeFirst
{

    public class Program
    {
        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(15));
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var _url = MyConfig.GetValue<string>("ConnectionStrings:url");


            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError() // HttpRequestException, 5XX and 408
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
           
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IConfiguracionMVC, ConfiguracionMvc>();

            
            var circuitBreakerPolicy = GetCircuitBreakerPolicy();

           

            builder.Services.AddScoped<IPedidoRepositorio, EFRepositoryPedidos>();
           

          
            builder.Services
                .AddHttpClient<IRepositorio<Componente>,APIComponentesRepository>(o =>
                    o.BaseAddress = new Uri(_url + "/api/")).AddPolicyHandler(retryPolicy);

            builder.Services.AddHttpClient<IRepositorioOrdenador, APIOrdenadorRepository>(o =>
                o.BaseAddress = new Uri(_url + "/api/")).AddPolicyHandler(retryPolicy);

            builder.Services.AddHttpClient<IPedidoRepositorio,
            APIPedidosRepository>(o =>
                o.BaseAddress = new Uri(_url + "/api/")).AddPolicyHandler(retryPolicy);





            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Componentes}/{action=Index}/{id?}");

            app.Run();
        }
    }
}