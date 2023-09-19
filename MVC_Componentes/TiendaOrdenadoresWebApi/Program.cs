using TiendaOrdenadoresWebApi.Models;
using TiendaOrdenadoresWebApi.Services;

namespace TiendaOrdenadoresWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddScoped<ADOContext>();
			builder.Services.AddScoped<IRepositorio<Componente>,RepositorioComponenteADO>();
			builder.Services.AddScoped<IRepositorio<Ordenador>, RepositorioOrdenadorADO>();
		
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}