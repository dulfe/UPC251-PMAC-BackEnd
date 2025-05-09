using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Xml.XPath;
using TrackingSystem.Backend.Swagger.Filters;
using TrackingSystem.BusinessLogic;
using TrackingSystem.DataModel;
using AspNetCore.Swagger.Themes;
using TrackingSystem.Backend.Auth;
using Microsoft.AspNetCore.Diagnostics;
using TrackingSystem.Backend.Entities;
using System.Drawing.Printing;

namespace TrackingSystem.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Obtener la configuración de la aplicación
            var config = builder.Configuration;

            // Imprimir la configuración de la aplicación
            PrintSettings(config);

            // Definir Servicios (dependencias)

            // -- Memoria Cache (in-memory)
            builder.Services.AddMemoryCache();

            // -- Base de datos usando Entity Framework Core
            builder.Services.AddDbContext<TrackingDataContext>((options) =>
            {
                Console.WriteLine(config.GetConnectionString("DefaultConnection"));
                // Usar SQL Server como proveedor de base de datos
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            // -- Logica de Negocio
            builder.Services.AddScoped<ISeguimientoDeOrdenesLogic, SeguimientoDeOrdenesLogic>();
            builder.Services.AddScoped<IUsuariosLogic, UsuariosLogic>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            // -- Configurar autenticación
            var identitySettings = config.GetSection("IdentitySettings").Get<IdentitySettings>();
            builder.Services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = identitySettings!.ServerURL;
                  options.RequireHttpsMetadata = false;
                  options.RefreshOnIssuerKeyNotFound = true;
                  options.TokenValidationParameters.ValidateAudience = false;
              });

            // -- Configurar CORS para permitir solicitudes desde cualquier origen
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            // -- Agregar servicios de controladores a la aplicación.
            builder.Services.AddControllers();

            // -- Agregar Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var info = config.GetRequiredSection("SwaggerDoc").Get<OpenApiInfo>();
                if (info == null)
                {
                    throw new InvalidOperationException("No se encontró la configuración de SwaggerDoc en el archivo de configuración.");
                }

                //c.SwaggerDoc("v1", new() { Title = "BetonDecken - Sistema de Seguimiento API", Version = "v1" });
                c.SwaggerDoc(info.Version, info);

                // Documentar los tipos de respuesta
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(() => new XPathDocument(xmlPath));

                // Agregar filtros globales
                c.OperationFilter<UnauthorizedResponsesOperationFilter>();
                c.OperationFilter<GlobalExceptionResponseOperationFilter>();

                // Agregar Autorización tipo Bearer a Swagger
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Por favor ingrese JWT dentro del campo Bearer. El token se puede obtener usando /Usuarios/Login",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = Microsoft.OpenApi.Models.ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            // Configurar Servicios

            // -- Configurar la configuración de identidad usando IOptions Pattern
            builder.Services.Configure<IdentitySettings>(config.GetSection("IdentitySettings"));

            // Construir la aplicación
            var app = builder.Build();

            // Configurar la canalización de solicitudes HTTP.
            app.UseSwagger();
            if (app.Environment.IsDevelopment())
            {
                // Habilitar la documentación de Swagger
                app.UseSwaggerUI(ModernStyle.DeepSea);
            }

            // Configurar el manejo de errores
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;
                    SimpleError errorResponse;

                    if (exception != null)
                    {
                        // Nota: No se debe devolver el mensaje de error original al cliente.
                        // Pero para fines de depuración/ejemplo, se puede devolver el mensaje de error original.
                        errorResponse = new SimpleError(500, "Un error inesperado ha ocurrido: " + exception.Message);
                    }
                    else
                    {
                        errorResponse = new SimpleError(500, "Un error inesperado ha ocurrido.");
                    }

                    await context.Response.WriteAsJsonAsync(errorResponse);
                });
            });

            // Configurar la redirección HTTPS
            app.UseHttpsRedirection();
            // Habilitar el middleware de CORS
            app.UseCors("AllowAll");
            // Habilitar el middleware de autenticación
            app.UseAuthentication();
            // Habilitar el middleware de autorización
            app.UseAuthorization();

            // Habilitar el middleware de punto final
            app.MapControllers();

            // Ejecutar la aplicación!
            app.Run();
        }

        private static void PrintSettings(IConfiguration config)
        {
            Console.WriteLine("Environment Variables:");
            foreach (var env in Environment.GetEnvironmentVariables().Keys)
            {
                Console.WriteLine($"{env}: {Environment.GetEnvironmentVariable(env.ToString())}");
            }
            Console.WriteLine("\nAppSettings:");
            foreach (var section in config.AsEnumerable())
            {
                Console.WriteLine($"{section.Key}: {section.Value}");
            }
        }
    }
}
