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
            services.AddScoped<IBaseRepository<Transformer.Transformer>, Transformer.Repository>();
            services.AddScoped<IBaseRepository<AltMode.AltMode>, AltMode.Repository>();
            services.AddScoped<IGetById<Transformer.Transformer>, Handler<Transformer.Transformer>>();
            services.AddScoped<IGetAll<Transformer.Transformer>, Handler<Transformer.Transformer>>();
            services.AddScoped<IGetById<AltMode.AltMode>, Handler<AltMode.AltMode>>();
            services.AddScoped<IGetAll<AltMode.AltMode>, Handler<AltMode.AltMode>>();
            services.AddCarter();
        }
        
        public void Configure(IApplicationBuilder app) {
            app.UseCarter();
        }
    }
}
