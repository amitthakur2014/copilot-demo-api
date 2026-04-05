using CopilotDemo.Models;

namespace CopilotDemo.Tests;

public class UserEmailValidationTests
{
    [Fact]
    public void IsEmailValid_WithValidEmail_ReturnsTrue()
    {
        // Arrange
        var user = new User { Email = "test@example.com" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmailValid_WithAnotherValidEmail_ReturnsTrue()
    {
        // Arrange
        var user = new User { Email = "amit.thakur@company.co.uk" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmailValid_WithEmailWithNumbers_ReturnsTrue()
    {
        // Arrange
        var user = new User { Email = "user123@domain456.com" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmailValid_WithEmailWithSpecialChars_ReturnsTrue()
    {
        // Arrange
        var user = new User { Email = "user+tag@example.com" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmailValid_WithInvalidEmailNoAtSign_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = "invalidemail.com" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsEmailValid_WithInvalidEmailNoDomain_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = "invalid@" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsEmailValid_WithInvalidEmailNoLocalPart_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = "@example.com" };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsEmailValid_WithEmptyEmail_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = string.Empty };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsEmailValid_WithNullEmail_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = null! };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsEmailValid_WithWhitespaceEmail_ReturnsFalse()
    {
        // Arrange
        var user = new User { Email = "   " };

        // Act
        var result = user.IsEmailValid();

        // Assert
        Assert.False(result);
    }
}

public class UserRepositoryTests
{
    [Fact]
    public void GetUserById_WithValidId_ReturnsUser()
    {
        // Arrange
        int userId = 1;

        // Act
        var user = UserRepository.GetUserById(userId);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(1, user.Id);
        Assert.Equal("Amit", user.Name);
        Assert.Equal("amit@example.com", user.Email);
    }

    [Fact]
    public void GetUserById_WithDifferentValidId_ReturnsCorrectUser()
    {
        // Arrange
        int userId = 3;

        // Act
        var user = UserRepository.GetUserById(userId);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(3, user.Id);
        Assert.Equal("Jane Smith", user.Name);
        Assert.Equal("jane.smith@example.com", user.Email);
    }

    [Fact]
    public void GetUserById_WithInvalidNegativeId_ReturnsNull()
    {
        // Arrange
        int userId = -1;

        // Act
        var user = UserRepository.GetUserById(userId);

        // Assert
        Assert.Null(user);
    }

    [Fact]
    public void GetUserById_WithZeroId_ReturnsNull()
    {
        // Arrange
        int userId = 0;

        // Act
        var user = UserRepository.GetUserById(userId);

        // Assert
        Assert.Null(user);
    }

    [Fact]
    public void GetUserById_WithNonExistentId_ReturnsNull()
    {
        // Arrange
        int userId = 999;

        // Act
        var user = UserRepository.GetUserById(userId);

        // Assert
        Assert.Null(user);
    }

    [Fact]
    public void GetAllUsers_ReturnsAllUsers()
    {
        // Act
        var users = UserRepository.GetAllUsers();

        // Assert
        Assert.NotEmpty(users);
        Assert.Equal(5, users.Count);
    }

    [Fact]
    public void GetAllUsers_AllUsersHaveValidEmails()
    {
        // Act
        var users = UserRepository.GetAllUsers();

        // Assert
        foreach (var user in users)
        {
            Assert.True(user.IsEmailValid(), $"User {user.Id} has invalid email: {user.Email}");
        }
    }

    [Fact]
    public void GetAllUsers_ContainsExpectedUserIds()
    {
        // Act
        var users = UserRepository.GetAllUsers();
        var userIds = users.Select(u => u.Id).ToList();

        // Assert
        Assert.Contains(1, userIds);
        Assert.Contains(2, userIds);
        Assert.Contains(3, userIds);
        Assert.Contains(4, userIds);
        Assert.Contains(5, userIds);
    }
}
