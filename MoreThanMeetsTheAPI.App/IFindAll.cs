using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    public interface IFindAll<A> where A : class {

        public Func<HttpRequest, HttpResponse, RouteData, Task> FindAll();
    }
}
