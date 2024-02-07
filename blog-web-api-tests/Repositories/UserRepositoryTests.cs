using blog_web_api.Interfaces;
using blog_web_api.Repositories;

namespace blog_web_api_tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(CommonHelper.GetDapperContext());
        }

        [Fact]
        public void GetUsers_ReturnUserList()
        {
            // Arrange

            // Act
            var users = _userRepository.GetUsers().Result;

            // Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
            Assert.All(users, user => Assert.NotNull(user.Id));
        }
    }
}
