using Microsoft.AspNetCore.Mvc;
using CopilotDemo.Models;

namespace CopilotDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = new User
            {
                Id = 1,
                Name = "Amit",
                Email = "amit@example.com"
            };

            // Validate email format
            if (!user.IsEmailValid())
            {
                return BadRequest(new { error = "Invalid email format" });
            }

            return Ok(user);
        }
    }
}