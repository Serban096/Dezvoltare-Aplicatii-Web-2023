using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models.DTOs;
using Proiect.Models.DTOs.UserDTO;
using Proiect.Models.Enums;
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


        [AllowAnonymous]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await _userService.GetById(Id));
        }

        [AllowAnonymous]
        [HttpGet("get-by-username")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            return Ok(await _userService.GetByUsername(username));
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.Delete(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update-user")]
        public async Task<IActionResult> EditUser([FromBody] UserUpdateDTO user)
        {
            try
            {
                await _userService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<string> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            return await _userService.Login(userLoginDTO);
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            await _userService.Logout();
        }

        [HttpPost("register")]
        public async Task<string> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            return await _userService.Register(userRegistrationDTO);
        }

    }

}
