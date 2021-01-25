using System;
using System.Collections.Generic;
using System.Text;

namespace MoreThanMeetsTheAPI {
    
    public interface IRepositoryQueries {

        public string GetAll { get; }

        public string GetById { get; }
    }
}
