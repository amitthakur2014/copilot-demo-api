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
