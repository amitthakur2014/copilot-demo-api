using CopilotDemo.Controllers;
using CopilotDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemo.Tests;

public class UserControllerTests
{
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _controller = new UserController();
    }

    [Fact]
    public void GetUser_WithNoId_ReturnsDefaultUser()
    {
        // Act
        var result = _controller.GetUser(null);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var user = Assert.IsType<User>(okResult.Value);
        Assert.Equal(1, user.Id);
        Assert.Equal("Amit", user.Name);
        Assert.Equal("amit@example.com", user.Email);
    }

    [Fact]
    public void GetUser_WithValidId_ReturnsCorrectUser()
    {
        // Act
        var result = _controller.GetUser(2);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var user = Assert.IsType<User>(okResult.Value);
        Assert.Equal(2, user.Id);
        Assert.Equal("Rahul", user.Name);
        Assert.Equal("rahul@example.com", user.Email);
    }

    [Fact]
    public void GetUser_WithInvalidId_ReturnsBadRequest()
    {
        // Act
        var result = _controller.GetUser(0);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid user id", GetErrorMessage(badRequestResult.Value));
    }

    [Fact]
    public void GetUser_WithNegativeId_ReturnsBadRequest()
    {
        // Act
        var result = _controller.GetUser(-1);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid user id", GetErrorMessage(badRequestResult.Value));
    }

    [Fact]
    public void GetUser_WithNonExistingId_ReturnsNotFound()
    {
        // Act
        var result = _controller.GetUser(999);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("User not found", GetErrorMessage(notFoundResult.Value));
    }

    private static string? GetErrorMessage(object? value) =>
        value?.GetType().GetProperty("error")?.GetValue(value)?.ToString();
}

