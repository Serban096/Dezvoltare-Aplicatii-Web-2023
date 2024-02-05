using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Services.TeamService;
using Proiect.Services.UserService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult GetTeamByName([FromBody] string name)
        {
            return Ok(_teamService.GetTeamByName(name));
        }

        [HttpGet("all")]
        public IActionResult GetTeams()
        {
            return Ok(_teamService.GetAllTeams());
        }

        [HttpPost("CreateTeam")]
        public async Task<IActionResult> CreateTeam(TeamDTO team)
        {
            try
            {
                await _teamService.CreateTeam(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
