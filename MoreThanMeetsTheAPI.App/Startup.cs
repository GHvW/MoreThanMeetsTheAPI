using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MoreThanMeetsTheAPI {

    public class Startup {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<Config>(Configuration.GetConnectionString("Postgres"));
            services.AddCarter();
        }
        
        public void Configure(IApplicationBuilder app) {
            app.UseCarter();
        }
    }
}
