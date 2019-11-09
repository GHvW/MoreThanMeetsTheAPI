using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Carter.Response;
using Carter.Request;

namespace MoreThanMeetsTheAPI {
    public class Handler<A> : IGetById<A>, IGetAll<A> where A : class {

        IBaseRepository<A> repo;

        public Handler(IBaseRepository<A> repo) {
            this.repo = repo;
        }

        public Func<HttpRequest, HttpResponse, RouteData, Task> GetAll() {
            return async (req, res, routeData) => {
                try {
                    var data = await repo.FindAll();
                    await res.AsJson(data);
                } catch (Exception ex) {
                    Console.WriteLine($"Issue: {ex.ToString()}");
                }
            };
        }

        public Func<HttpRequest, HttpResponse, RouteData, Task> GetById() {
            return async (req, res, routeData) => {
                var id = routeData.As<int>("id");
                var data = await repo.FindById(id);
                await res.AsJson(data);
            };
        }
    }
}
