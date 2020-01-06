using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Transformer {
    public class Queries {

        public readonly string GetAll = "SELECT * FROM transformer_view";
        public readonly string GetById = "SELECT * FROM transformer_view WHERE id = @Id";
    }
}
