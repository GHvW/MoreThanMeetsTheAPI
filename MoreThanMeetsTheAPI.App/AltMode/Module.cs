using Carter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {

    public class Module : CarterModule {

        public Module(IGetAll<AltMode> allHandler, IGetById<AltMode> idHandler) {

            this.Get("/", allHandler.GetAll);

            this.Get("/{id:int}", idHandler.GetById);
        }
    }
}
