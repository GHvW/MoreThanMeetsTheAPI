using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI {
    
    public static class RequestExtensions {

        public static int ParsePage(this HttpRequest req) {
            // TODO - if page exists but doesnt parse, error. if no keys, return 1
            StringValues pageQuery;
            var pageExists = req.Query.TryGetValue("page", out pageQuery);
            if (!pageExists) {
                return 1;
            }

            int page;
            var isInt = int.TryParse(pageQuery, out page);

            if (!isInt) {
                return 0;
            }

            return page;
        }
    }
}
