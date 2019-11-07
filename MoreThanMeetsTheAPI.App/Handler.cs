using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Carter.Response;

namespace MoreThanMeetsTheAPI {
    public class Handler<A> : IFindById<A>, IFindAll<A> where A : class {

        IBaseRepository<A> repo;

        public Handler(IBaseRepository<A> repo) {
            this.repo = repo;
        }

        public Func<HttpRequest, HttpResponse, RouteData, Task> FindAll() {
            return async (req, res, routeData) => {
                var data = await repo.FindAll();
                await res.AsJson(data);
            };
        }

        public Func<HttpRequest, HttpResponse, RouteData, Task> IFindById(int id) {
            return async (req, res, routeData) => {
                var data = await repo.FindById(id);
                await res.AsJson(data);
            };
        }
    }
}
