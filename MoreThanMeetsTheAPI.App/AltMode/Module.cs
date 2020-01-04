using Carter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {

    public class Module : CarterModule {

        public Module(IGetAll<Model> allHandler, IGetById<Model> idHandler) {

            this.Get("/", allHandler.GetAll);

            this.Get("/{id:int}", idHandler.GetById);
        }
    }
}
