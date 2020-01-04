using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Weapon {
    public class Weapon {

        public string? Name { get; set; }
        public IEnumerable<Transformer.Model> transformers { get; set; } = new List<Transformer.Model>();
        public DateTime? Created { get; set; }
        public string? url { get; set; }
    }
}
