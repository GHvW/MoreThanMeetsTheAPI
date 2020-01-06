using Carter;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MoreThanMeetsTheAPI.Transformer {

    public class Module : CarterModule {

        public Module(IGetById<Model> idHandler, IGetAll<Model> allHandler) {

            this.Get("/api/transformer/", allHandler.GetAll);


            this.Get("/api/transformer/{id:int}", idHandler.GetById);
        }
    }
}
