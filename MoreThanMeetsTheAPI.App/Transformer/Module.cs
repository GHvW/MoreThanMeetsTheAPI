using Carter;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MoreThanMeetsTheAPI.Transformer {

    public class Module : CarterModule {

        public Module(
            IGetById<Model> idHandler, 
            IGetAll<Model> allHandler, 
            IOptions<Routes> routes) 
            : base(routes.Value.Base) {

            this.Get("/", allHandler.GetAll);

            this.Get("/{id:int}", idHandler.GetById);
        }
    }
}
