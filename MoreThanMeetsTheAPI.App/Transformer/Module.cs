using Carter;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Transformer {
    class Module : CarterModule {

        public Module(Transformer.IRepository repo) {

            this.Get("/", async (req, res, routeData) => {
                var transformers = await repo.FindAll();
                await res.AsJson(transformers);
            });
        }
    }
}
