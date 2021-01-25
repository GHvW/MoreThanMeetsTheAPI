using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI.AltMode {
    
    public class Queries : IRepositoryQueries {

        public string GetAll { get; } = "SELECT * FROM alt_mode_view";

        public string GetById { get; } = "SELECT * FROM alt_mode_view WHERE id = @Id";
    }
}
