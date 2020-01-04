using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    public interface IGetAll<A> where A : class {

        public Task GetAll(HttpRequest req, HttpResponse res, RouteData routeData);
    }
}
