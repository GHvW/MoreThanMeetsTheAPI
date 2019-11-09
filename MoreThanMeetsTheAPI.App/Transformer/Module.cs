using Carter;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MoreThanMeetsTheAPI.Transformer {

    public class Module : CarterModule {

        public Module(IGetById<Transformer> idHandler, IGetAll<Transformer> allHandler) {

            this.Get("/api/transformer/", allHandler.GetAll());
            //this.Get("/api/transformer", async (req, res, routeData) => {
            //    await res.WriteAsync("Well, I got here");
            //});

            this.Get("/api/transformer/{id:int}", idHandler.GetById());
        }
    }
}
