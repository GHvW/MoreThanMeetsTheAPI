using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    public interface IBaseRepository<A> {
        public Task<IEnumerable<A>> FindAll();
        public Task<A?> FindById(int id);
    }
}
