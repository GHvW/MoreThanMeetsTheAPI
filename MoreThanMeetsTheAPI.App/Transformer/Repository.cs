using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

//namespace MoreThanMeetsTheAPI.Transformer {

//    public class Repository : IRepository<Model> {

//        string connectionString;

//        public Repository(IConfiguration config) {
//            this.connectionString = config.GetConnectionString("Postgres");
//        }

//        private IDbConnection connect(string connString) => new NpgsqlConnection(connString);

//        public async Task<IEnumerable<Model>> FindAll() {
//            using (var conn = connect(this.connectionString)) {
//                conn.Open();
//                return await conn.QueryAsync<Model>("SELECT * FROM transformer_view");
//            }
//        }

//        public async Task<Model?> FindById(int id) {
//            using (var conn = connect(this.connectionString)) {
//                conn.Open();
//                return await conn.QuerySingleAsync<Model>("SELECT * FROM transformer_view WHERE id = @Id", new { Id = id });
//            }
//        }
//    }
//}
