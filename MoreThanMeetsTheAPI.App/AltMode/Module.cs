using Carter;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {

    public class Module : CarterModule {

        public Module(
            IGetAll<Model> allHandler, 
            IGetById<Model> idHandler, 
            IOptions<Routes> routes) 
            : base(routes.Value.Base) {

            this.Get("/", allHandler.GetAll);

            this.Get("/{id:int}", idHandler.GetById);
        }
    }
}
