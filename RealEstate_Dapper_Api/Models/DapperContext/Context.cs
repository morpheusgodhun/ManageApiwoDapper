using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ManageApiwoDapper_Api.Models.DapperContext {
    public class Context {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration) {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }
       public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
