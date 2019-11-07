using Carter;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Transformer {
    class Module : CarterModule {

        public Module(Handler<Transformer> handler) {

            this.Get("/", handler.GetAll());

            this.Get("/{id:int}", handler.GetById())
        }
    }
}
