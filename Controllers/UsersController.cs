using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Services.UserService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserByUserName([FromBody] string username)
        {
            return Ok(_userService.GetUserByUsername(username));
        }
    }
}
