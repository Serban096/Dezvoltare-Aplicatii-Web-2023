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
            var response = await _userService.Register(userRegistrationDTO, Models.Enums.Role.User);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee(Models.DTOs.UserDTO.UserRegistrationDTO userRegistrationDTO)
        {
            var response = await _userService.Register(userRegistrationDTO, Models.Enums.Role.Admin);

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
            return Ok(_userService.GetAllUsers());
        }

        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok(new { Message = "Account is logged in" });
        }


        [Authorize(Role.User)]
        [HttpGet("check-auth-customer")]
        public IActionResult GetTextCustomer()
        {
            return Ok(new { Message = "Customer is logged in" });
        }

        [Authorize(Role.Admin)]
        [HttpGet("check-auth-employee")]
        public IActionResult GetTextEmployee()
        {
            return Ok(new { Message = "Employee is logged in" });
        }


    }
}
