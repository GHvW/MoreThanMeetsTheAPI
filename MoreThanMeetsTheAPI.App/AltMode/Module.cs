using Carter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {

    public class Module : CarterModule {

        public Module(IGetAll<Model> allHandler, IGetById<Model> idHandler) {

            this.Get("api/altdmode/", allHandler.GetAll);

            this.Get("api/altmode/{id:int}", idHandler.GetById);
        }
    }
}
