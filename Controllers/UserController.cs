using Microsoft.AspNetCore.Mvc;

namespace CopilotDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = new
            {
                Id = 1,
                Name = "Amit"
            };

            return Ok(user);
        }
    }
}