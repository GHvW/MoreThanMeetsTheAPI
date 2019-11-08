using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI.Transformer {

    public class Repository : IBaseRepository<Transformer> {

        string connectionString;

        public Repository(IConfiguration config) {
            this.connectionString = config.GetConnectionString("Postgres");
        }

        private IDbConnection connect(string connString) => new SqlConnection(connString);

        public async Task<IEnumerable<Transformer>> FindAll() {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QueryAsync<Transformer>("SELECT * FROM transformer_view");
            }
        }

        public async Task<Transformer?> FindById(int id) {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QuerySingleAsync<Transformer>("SELECT * FROM transformer_view WHERE id = @Id", new { Id = id });
            }
        }
    }
}
