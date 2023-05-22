using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Users;
using trailblazers_api.Services.Users;
using trailblazers_api.Utils;
using Xunit;

namespace trailblazers_api.Tests.Services.Users
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly JwtSettings _jwtSettings;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _jwtSettings = new JwtSettings
            {
                Key = "test-key",
                Issuer = "test-issuer",
                Audience = "test-audience"
            };

            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object, _jwtSettings);
        }

        [Fact]
        public async Task Authenticate_ValidUser_ReturnsTrue()
        {
            // Arrange
            var userDto = new UserCreationLoginDto { Name = "TestUser", Password = "TestPassword" };
            var user = new User { Name = "TestUser", Password = "TestPassword" };

            _userRepositoryMock.Setup(x => x.GetUserByName(userDto.Name)).ReturnsAsync(user);

            // Act
            var result = await _userService.Authenticate(userDto);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Authenticate_InvalidUser_ReturnsFalse()
        {
            // Arrange
            var userDto = new UserCreationLoginDto { Name = "TestUser", Password = "TestPassword" };

            _userRepositoryMock.Setup(x => x.GetUserByName(userDto.Name)).ReturnsAsync((User)null!);

            // Act
            var result = await _userService.Authenticate(userDto);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetCurrentUser_InvalidHttpContext_ReturnsNull()
        {
            // Arrange
            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User.Identity).Returns((ClaimsIdentity)null!);

            // Act
            var result = await _userService.GetCurrentUser(contextMock.Object);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserById_ExistingId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId };

            _userRepositoryMock.Setup(x => x.GetUserById(userId)).ReturnsAsync(user);
            _mapperMock.Setup(x => x.Map<UserAccessDto>(user)).Returns(_mapperMock.Object.Map<UserAccessDto>(user));

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            Assert.Equal(_mapperMock.Object.Map<UserAccessDto>(user), result);
        }

        [Fact]
        public async Task GetUserById_NonExistingId_ReturnsNull()
        {
            // Arrange
            var userId = 1;

            _userRepositoryMock.Setup(x => x.GetUserById(userId)).ReturnsAsync((User)null!);

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserByName_ExistingName_ReturnsUser()
        {
            // Arrange
            var userName = "TestUser";
            var user = new User { Name = userName };

            _userRepositoryMock.Setup(x => x.GetUserByName(userName)).ReturnsAsync(user);
            _mapperMock.Setup(x => x.Map<UserAccessDto>(user)).Returns(_mapperMock.Object.Map<UserAccessDto>(user));

            // Act
            var result = await _userService.GetUserByName(userName);

            // Assert
            Assert.Equal(_mapperMock.Object.Map<UserAccessDto>(user), result);
        }

        [Fact]
        public async Task GetUserByName_NonExistingName_ReturnsNull()
        {
            // Arrange
            var userName = "TestUser";

            _userRepositoryMock.Setup(x => x.GetUserByName(userName)).ReturnsAsync((User)null!);

            // Act
            var result = await _userService.GetUserByName(userName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateUserByName_ValidUser_ReturnsTrue()
        {
            // Arrange
            var updatedUser = new UserUpdateDto { Name = "TestUser" };
            var userToUpdate = new User { Name = "TestUser" };

            _mapperMock.Setup(x => x.Map<User>(updatedUser)).Returns(userToUpdate);
            _userRepositoryMock.Setup(x => x.UpdateUser(userToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _userService.UpdateUserByName(updatedUser);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ExistingName_ReturnsTrue()
        {
            // Arrange
            var userName = "TestUser";

            _userRepositoryMock.Setup(x => x.DeleteUser(userName)).ReturnsAsync(true);

            // Act
            var result = await _userService.DeleteUser(userName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_NonExistingName_ReturnsFalse()
        {
            // Arrange
            var userName = "TestUser";

            _userRepositoryMock.Setup(x => x.DeleteUser(userName)).ReturnsAsync(false);

            // Act
            var result = await _userService.DeleteUser(userName);

            // Assert
            Assert.False(result);
        }
    }
}
