using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI.Weapon {

    class Repository {
        string connectionString;

        public Repository(IConfiguration config) {
            this.connectionString = config.GetConnectionString("Postgres");
        }

        private IDbConnection connect(string connString) => new SqlConnection(connString);

        public async Task<IEnumerable<Weapon>> FindAll() {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QueryAsync<Weapon>("SELECT * FROM weapon_view");
            }
        }

        public async Task<Weapon?> FindById(int id) {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QuerySingleAsync<Weapon>("SELECT * FROM weapon_view WHERE id = @Id", new { Id = id });
            }
        }
    }
}
