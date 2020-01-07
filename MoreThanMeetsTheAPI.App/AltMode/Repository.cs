using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

//namespace MoreThanMeetsTheAPI.AltMode {

//    public class Repository : IRepository<Model> {

//        private string connectionString;

//        public Repository(IConfiguration config) {
//            this.connectionString = config.GetConnectionString("Postgres");
//        }

//        private IDbConnection Connect(string connString) => new NpgsqlConnection(connString);

//        public async Task<IEnumerable<Model>> FindAll() {
//            using (var conn = Connect(this.connectionString)) { // ADO.NET creates a connection pool on its own behind the scenes per connection string, so if the string is the same, it uses the same connection pool
//                conn.Open();
//                return await conn.QueryAsync<Model>("SELECT * FROM alt_mode_view");
//            }
//        }

//        public async Task<Model?> FindById(int id) {
//            using (var conn = Connect(this.connectionString)) {
//                conn.Open();
//                return await conn.QuerySingleAsync<Model>("SELECT * FROM alt_mode_view WHERE id = @Id", new { Id = id });
//            }
//        }
//    }
//}
