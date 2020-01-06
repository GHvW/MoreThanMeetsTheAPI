using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    public class Repository<A> : IRepository<A> where A : class {

        string connectionString;
        string getAllSql;
        string getByIdSql;

        public Repository(IConfiguration config, string getAllSql, string getByIdSql) {
            this.connectionString = config.GetConnectionString("Postgres");
            this.getAllSql = getAllSql;
            this.getByIdSql = getByIdSql;
        }

        private IDbConnection Connect(string connString) => new NpgsqlConnection(connString);

        public async Task<IEnumerable<A>> FindAll() {
            using (var conn = Connect(this.connectionString)) { // ADO.NET creates a connection pool on its own behind the scenes per connection string, so if the string is the same, it uses the same connection pool
                conn.Open();
                return await conn.QueryAsync<A>(this.getAllSql);
            }
        }

        public async Task<A?> FindById(int id) {
            using (var conn = Connect(this.connectionString)) {
                conn.Open();
                return await conn.QuerySingleAsync<A>(this.getByIdSql, new { Id = id });
            }
        }
    }
}
