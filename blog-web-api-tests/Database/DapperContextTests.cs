using blog_web_api.Database;
using blog_web_api_shared.DataTransferObjects;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_web_api_tests.Database
{
    public class DapperContextTests
    {
        [Fact]
        public void GetConnectionString_ReturnsCorrectConnectionString()
        {
            // Arrange
            var connectionDbOptions = Options.Create(new ConnectionDb
            {
                Host = "localhost",
                Port = 5432,
                Database = "mydatabase",
                Username = "myuser",
                Hash = "mypassword"
            });

            var dapperContext = new DapperContext(connectionDbOptions);

            // Act
            var connectionString = dapperContext.GetConnectionString();

            // Assert
            var expectedConnectionString = "Server=localhost;Port=5432;Database=mydatabase;User Id=myuser;Password=mypassword;";
            Assert.Equal(expectedConnectionString, connectionString);
        }

        [Fact]
        public void GetConnection_ReturnsSqlConnection()
        {
            // Arrange
            var connectionDbOptions = Options.Create(new ConnectionDb
            {
                Host = "localhost",
                Port = 5432,
                Database = "mydatabase",
                Username = "myuser",
                Hash = "mypassword"
            });

            var dapperContext = new DapperContext(connectionDbOptions);

            // Act
            var connection = dapperContext.GetConnection();

            // Assert
            Assert.Equal(typeof(NpgsqlConnection), connection.GetType());
        }
    }
}
