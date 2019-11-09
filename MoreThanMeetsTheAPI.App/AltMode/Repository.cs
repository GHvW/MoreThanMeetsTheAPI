﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MoreThanMeetsTheAPI.AltMode {
    public class Repository : IBaseRepository<AltMode> {

        string connectionString;

        public Repository(IConfiguration config) {
            this.connectionString = config.GetConnectionString("Postgres");
        }

        private IDbConnection connect(string connString) => new NpgsqlConnection(connString);

        public async Task<IEnumerable<AltMode>> FindAll() {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QueryAsync<AltMode>("SELECT * FROM alt_mode_view");
            }
        }

        public async Task<AltMode?> FindById(int id) {
            using (var conn = connect(this.connectionString)) {
                conn.Open();
                return await conn.QuerySingleAsync<AltMode>("SELECT * FROM alt_mode_view WHERE id = @Id", new { Id = id });
            }
        }
    }
}
