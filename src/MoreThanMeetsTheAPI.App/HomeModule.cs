namespace MoreThanMeetsTheAPI
{
    using Carter;
    using Microsoft.AspNetCore.Http;

    public class HomeModule : CarterModule {

        public HomeModule() {
            Get("/api", async(req, res, routeData) => await res.WriteAsync("Hello from Carter!"));
        }
    }
}
