using Microsoft.AspNetCore.Mvc;
using CopilotDemo.Models;

namespace CopilotDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get user by ID from query parameter
        /// </summary>
        /// <param name="id">User ID (optional, defaults to 1)</param>
        /// <returns>User object if valid ID is provided and email is valid</returns>
        [HttpGet]
        public IActionResult GetUser([FromQuery] int? id = null)
        {
            // Use default ID if not provided
            int userId = id ?? 1;

            // Validate ID parameter (must be positive)
            if (userId <= 0)
            {
                return BadRequest(new { error = "Invalid user id" });
            }

            // Retrieve user from repository
            var user = UserRepository.GetUserById(userId);

            // Return 404 if user not found
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            // Validate email format
            if (!user.IsEmailValid())
            {
                return BadRequest(new { error = "Invalid email format" });
            }

            return Ok(user);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = UserRepository.GetAllUsers();
            return Ok(users);
        }
    }
}