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
            // make transirnt?
            services.AddScoped<IBaseRepository<Transformer.Model>, Transformer.Repository>();
            services.AddScoped<IBaseRepository<AltMode.Model>, AltMode.Repository>();
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
