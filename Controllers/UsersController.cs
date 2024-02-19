using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(Models.DTOs.UserDTO.UserLoginDTO userLoginDTO)
        {
            var response = await _userService.Login(userLoginDTO);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(Models.DTOs.UserDTO.UserRegistrationDTO userRegistrationDTO)
        {
            var response = await _userService.Register(userRegistrationDTO, Role.User);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRegistrationDTO userRegistrationDTO)
        {
            var response = await _userService.Register(userRegistrationDTO, Role.Admin);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("get-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok(new { Message = "Account is logged in" });
        }


        [Authorize(Roles = "User")]
        [HttpGet("check-auth-user")]
        public IActionResult GetTextUser()
        {
            return Ok(new { Message = "User is logged in" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("check-auth-admin")]
        public IActionResult GetTextAdmin()
        {
            return Ok(new { Message = "Admin is logged in" });
        }
        [HttpDelete]
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

        [HttpPatch]
        public async Task<IActionResult> EditUser([FromBody] UserLoginResponse user)
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

    }



}
