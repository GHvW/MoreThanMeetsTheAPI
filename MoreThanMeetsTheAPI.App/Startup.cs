using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace MoreThanMeetsTheAPI {

    public class Startup {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        public void ConfigureServices(IServiceCollection services) {
            //services.Configure<Config>(Configuration.GetConnectionString("Postgres"));
            services.AddSingleton(Configuration);

            services.Configure<Transformer.Routes>(routes => {
                routes.Base = "/api/transformer";
            });
            services.Configure<AltMode.Routes>(routes => {
                routes.Base = "/api/altmode";
            });

            services.AddSingleton<Transformer.Queries>();
            services.AddSingleton<AltMode.Queries>();
            // make transient?
            //services.AddScoped<IRepository<Transformer.Model>, Transformer.Repository>();
            services.AddScoped<IRepository<Transformer.Model>, Repository<Transformer.Model, Transformer.Queries>>();
            //services.AddScoped<IRepository<AltMode.Model>, AltMode.Repository>();
            services.AddScoped<IRepository<AltMode.Model>, Repository<AltMode.Model, AltMode.Queries>>();
            services.AddScoped<IGetById<Transformer.Model>, Handler<Transformer.Model>>();
            services.AddScoped<IGetAll<Transformer.Model>, Handler<Transformer.Model>>();
            services.AddScoped<IGetById<AltMode.Model>, Handler<AltMode.Model>>();
            services.AddScoped<IGetAll<AltMode.Model>, Handler<AltMode.Model>>();
            
            services.AddCarter();
        }
        
        public void Configure(IApplicationBuilder app) {
            app.UseCarter();
        }
    }
}
