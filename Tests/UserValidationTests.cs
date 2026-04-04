using CopilotDemo.Models;
using Xunit;

namespace CopilotDemo.Tests
{
    /// <summary>
    /// Unit tests for User model email validation
    /// </summary>
    public class UserValidationTests
    {
        [Fact]
        public void IsEmailValid_WithValidEmail_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "test@example.com"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmailValid_WithValidComplexEmail_ReturnsTrue()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "john.doe+tag@example.co.uk"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmailValid_WithInvalidEmailNoAtSymbol_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "testexample.com"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmailValid_WithInvalidEmailNoDomain_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "test@"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmailValid_WithInvalidEmailNoLocalPart_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "@example.com"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmailValid_WithInvalidEmailNoTLD_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = "test@example"
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmailValid_WithEmptyEmail_ReturnsFalse()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Test User",
                Email = ""
            };

            // Act
            bool result = user.IsEmailValid();

            // Assert
            Assert.False(result);
        }
    }
}
