using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    public interface IRepository<A> where A : class {

        public Task<IEnumerable<A>> FindAll(int page);

        public Task<A?> FindById(int id);
    }
}
