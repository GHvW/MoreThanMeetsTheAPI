using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.Weapon {
    public class Weapon {

        public string Name { get; set; }
        public IEnumerable<Transformer.Transformer> transformers { get; set; } = new List<Transformer.Transformer>();
        public DateTime Created { get; set; }
        public string url { get; set; }
    }
}
