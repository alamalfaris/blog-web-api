using blog_web_api.Controllers;
using blog_web_api.Interfaces;
using blog_web_api_shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_web_api_tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUsersV1_ReturnsOkResultWithUsers()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var expectedUsers = CommonHelper.GetExpectedUsers();
            userServiceMock.Setup(x => x.GetUsers()).ReturnsAsync(expectedUsers);

            var userController = new UserController(userServiceMock.Object);

            // Act
            var result = await userController.GetUsersV1();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUsers = Assert.IsType<List<User>>(okResult.Value);
            Assert.Equal(expectedUsers, actualUsers);
        }

        [Fact]
        public async Task GetUsersV1_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.GetUsers()).ThrowsAsync(new Exception("Some error"));

            var userController = new UserController(userServiceMock.Object);

            // Act
            var result = await userController.GetUsersV1();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
