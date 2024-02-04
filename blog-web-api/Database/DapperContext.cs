using blog_web_api_shared.DataTransferObjects;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace blog_web_api.Database
{
    public class DapperContext
    {
        private readonly ConnectionDb _connectionDb;
        
        public DapperContext(IOptions<ConnectionDb> connectionDb)
        {
            _connectionDb = connectionDb.Value;
        }

        public string GetConnectionString()
        {
            return $"Server={_connectionDb.Host};Port={_connectionDb.Port};Database={_connectionDb.Database};User Id={_connectionDb.Username};Password={_connectionDb.Hash};";
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(GetConnectionString());
        }
    }
}
