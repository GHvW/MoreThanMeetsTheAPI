using Carter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {

    public class Module : CarterModule {

        public Module(Handler<AltMode> handler) {

            this.Get("/", handler.GetAll());

            this.Get("/{id:int}", handler.GetById());
        }
    }
}
