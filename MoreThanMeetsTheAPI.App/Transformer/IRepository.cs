using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI.Transformer {
    public interface IRepository {
        public Task<IEnumerable<Transformer.Dto>> FindAll();
        public Task<Transformer.Dto?> FindById(int id);
    }
}
