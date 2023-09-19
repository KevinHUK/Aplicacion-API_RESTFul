using Microsoft.EntityFrameworkCore;
using MVC_ComponentesDatabaseFirst.Models;
using MVC_ComponentesDatabaseFirst.Services;

namespace MVC_ComponentesDatabaseFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IComponenteRepositorio, EFRepository>();
            builder.Services.AddDbContext<ComponentesDatabaseFirstContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}