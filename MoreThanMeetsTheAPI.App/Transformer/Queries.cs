using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Transformer {

    public class Queries : IRepositoryQueries {

        public string GetAll { get; } = "SELECT * FROM transformer_view";

        public string GetById { get; } = "SELECT * FROM transformer_view WHERE id = @Id";
    }
}
