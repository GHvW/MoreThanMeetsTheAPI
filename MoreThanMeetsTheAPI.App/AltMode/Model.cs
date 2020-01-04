using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {
    public class Model {

        public string? Type { get; set; }
        public string? Subtype { get; set; }
        public string? Family { get; set; }
        public string? Kind { get; set; }
        public IEnumerable<int> Transformers { get; set; } = new List<int>();
        public string? Url { get; set; }
        public DateTime? created { get; set; }
    }
}
