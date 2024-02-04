using blog_web_api.Database;
using blog_web_api.Repositories;
using blog_web_api_shared.Entities;
using Dapper;
using Moq;
using Moq.Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_web_api_tests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUsers_ReturnsListOfUsers()
        {
            // Arrange
            var contextMock = new Mock<DapperContext>();

            var userRepository = new UserRepository(contextMock.Object);

            var expectedUsers = new List<User>
            {
                new() { Id = "1aq2wse", Name = "User1", Email = "user1@example.com", CreatedDate = DateTime.Now },
                new() { Id = "z2ws3edf", Name = "User2", Email = "user2@example.com", CreatedDate = DateTime.Now }
            };

            var queryResultMock = new Mock<IEnumerable<User>>();
            queryResultMock.Setup(x => x.ToList()).Returns(expectedUsers);

            var dbConnectionMock = new Mock<IDbConnection>();
            dbConnectionMock.SetupDapperAsync(x => x.QueryAsync<User>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(queryResultMock.Object);

            contextMock.Setup(x => x.GetConnection()).Returns(dbConnectionMock.Object);

            // Act
            var users = await userRepository.GetUsers();

            // Assert
            Assert.Equal(expectedUsers, users);
        }
    }
}
