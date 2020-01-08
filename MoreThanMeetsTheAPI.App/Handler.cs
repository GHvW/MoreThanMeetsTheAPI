using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Carter.Response;
using Carter.Request;

namespace MoreThanMeetsTheAPI {

    public class Handler<A> : IGetById<A>, IGetAll<A> where A : class {

        IRepository<A> repo; // azure repos code coverage https://docs.microsoft.com/en-us/azure/devops/pipelines/test/codecoverage-for-pullrequests?view=azure-devops

        public Handler(IRepository<A> repo) {
            this.repo = repo;
        }

        public async Task GetAll(HttpRequest req, HttpResponse res, RouteData routeData) {
            try {
                var data = await repo.FindAll();
                await res.AsJson(data);
            } catch (Exception ex) {
                Console.WriteLine($"Issue: {ex.ToString()}");
            }
        }

        public async Task GetById(HttpRequest req, HttpResponse res, RouteData routeData) {
            try {
                var id = routeData.As<int>("id");
                var data = await repo.FindById(id);
                await res.AsJson(data);
            } catch (Exception ex) {
                Console.WriteLine($"Issue: {ex.ToString()}");
            }
        }
        //public Func<HttpRequest, HttpResponse, RouteData, Task> GetAll() {
        //    return async (req, res, routeData) => {
        //        try {
        //            var data = await repo.FindAll();
        //            await res.AsJson(data);
        //        } catch (Exception ex) {
        //            Console.WriteLine($"Issue: {ex.ToString()}");
        //        }
        //    };
        //}

        //public Func<HttpRequest, HttpResponse, RouteData, Task> GetById() {
        //    return async (req, res, routeData) => {
        //        var id = routeData.As<int>("id");
        //        var data = await repo.FindById(id);
        //        await res.AsJson(data);
        //    };
        //}
    }
}
