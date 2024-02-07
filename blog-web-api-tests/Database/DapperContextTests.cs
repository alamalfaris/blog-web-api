using blog_web_api.Database;
using Npgsql;

namespace blog_web_api_tests.Database
{
    public class DapperContextTests
    {
        private readonly DapperContext _dapperContext;

        public DapperContextTests()
        {
            _dapperContext = CommonHelper.GetDapperContext();
        }

        [Fact]
        public void GetConnectionString_ReturnsCorrectConnectionString()
        {
            // Arrange
            

            // Act
            var connectionString = _dapperContext.GetConnectionString();

            // Assert
            var expectedConnectionString = "Server=localhost;Port=5432;Database=blog-web-tests;User Id=postgres;Password=!suPer12@;";
            Assert.Equal(expectedConnectionString, connectionString);
        }

        [Fact]
        public void GetConnection_ReturnsSqlConnection()
        {
            // Arrange
            

            // Act
            var connection = _dapperContext.GetConnection();

            // Assert
            Assert.Equal(typeof(NpgsqlConnection), connection.GetType());
        }
    }
}
