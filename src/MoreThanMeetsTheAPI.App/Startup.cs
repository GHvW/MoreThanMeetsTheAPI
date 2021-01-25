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

            var prefix = "/api"; // put this in configuration file appsettings.json
            services.Configure<Transformer.Routes>(routes => {
                routes.Base = $"{prefix}/transformer";
            });
            services.Configure<AltMode.Routes>(routes => {
                routes.Base = $"{prefix}/altmode";
            });
            services.Configure<Weapon.Routes>(routes => {
                routes.Base = $"{prefix}/weapon";
            });
            services.Configure<Series.Routes>(routes => {
                routes.Base = $"{prefix}/series";
            });

            services.AddSingleton<Transformer.Queries>();
            services.AddSingleton<AltMode.Queries>();
            services.AddSingleton<Weapon.Queries>();
            // make transient?
            //services.AddScoped<IRepository<Transformer.Model>, Transformer.Repository>();
            services.AddScoped<IRepository<Transformer.Model>, Repository<Transformer.Model, Transformer.Queries>>();

            //services.AddScoped<IRepository<AltMode.Model>, AltMode.Repository>();
            services.AddScoped<IRepository<AltMode.Model>, Repository<AltMode.Model, AltMode.Queries>>();

            services.AddScoped<IRepository<Weapon.Model>, Repository<Weapon.Model, Weapon.Queries>>();
            //services.AddScoped<IRepository<Series.Model>, Repository<Series.Model, Series.Queries>>();
            services.AddScoped<IGetById<Transformer.Model>, Handler<Transformer.Model>>();
            services.AddScoped<IGetAll<Transformer.Model>, Handler<Transformer.Model>>();

            services.AddScoped<IGetById<AltMode.Model>, Handler<AltMode.Model>>();
            services.AddScoped<IGetAll<AltMode.Model>, Handler<AltMode.Model>>();

            services.AddScoped<IGetById<Weapon.Model>, Handler<Weapon.Model>>();
            services.AddScoped<IGetAll<Weapon.Model>, Handler<Weapon.Model>>();
            
            // TODO - this is where we can use hooks for security etc
            services.AddCarter();
        }
        
        public void Configure(IApplicationBuilder app) {
            app.UseCarter();
        }
    }
}
