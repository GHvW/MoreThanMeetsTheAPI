using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI {
    
    public class Repository<A, B> : IRepository<A> 
        where A : class
        where B : IRepositoryQueries {

        string connectionString;
        B queries;

        public Repository(IConfiguration config, B queries) {
            this.connectionString = config.GetConnectionString("Postgres");
            this.queries = queries;
        }

        private IDbConnection Connect(string connString) => new NpgsqlConnection(connString);

        public async Task<IEnumerable<A>> FindAll(int page) {
            if (page == 0) return Enumerable.Empty<A>();

            using (var conn = Connect(this.connectionString)) { // ADO.NET creates a connection pool on its own behind the scenes per connection string, so if the string is the same, it uses the same connection pool
                conn.Open();
                return await conn.QueryAsync<A>(queries.GetAll, new { MinId = (page * 20) - 20, MaxId = page * 20 });
            }
        }

        public async Task<A?> FindById(int id) {
            using (var conn = Connect(this.connectionString)) {
                conn.Open();
                return await conn.QuerySingleAsync<A>(queries.GetById, new { Id = id });
            }
        }
    }
}
