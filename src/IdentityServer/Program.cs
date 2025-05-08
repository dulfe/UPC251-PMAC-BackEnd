using IdentityServer.Validation;
using IdentityServer8.Validation;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using TrackingSystem.DataModel;

namespace TrackingSystem.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Obtener la configuración de la aplicación
            var config = builder.Configuration;

            // Add services to the container.

            builder.Services.AddIdentityServer()
                .AddInMemoryApiScopes(ConfigIdentity.GetApiScopes())
                .AddInMemoryClients(ConfigIdentity.GetClients())
                .AddInMemoryApiResources(ConfigIdentity.GetApiResources())
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidatorService>()
                .AddDeveloperSigningCredential();


            builder.Services.AddDbContext<TrackingDataContext>((options) =>
            {
                // Usar SQL Server como proveedor de base de datos
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            // Configurar CORS para permitir solicitudes desde cualquier origen
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            //builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseIdentityServer();

            //app.UseAuthorization();

            //var summaries = new[]
            //{
            //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            //};

            //app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            //{
            //    var forecast = Enumerable.Range(1, 5).Select(index =>
            //        new WeatherForecast
            //        {
            //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //            TemperatureC = Random.Shared.Next(-20, 55),
            //            Summary = summaries[Random.Shared.Next(summaries.Length)]
            //        })
            //        .ToArray();
            //    return forecast;
            //});

            app.Run();
        }
    }
}
