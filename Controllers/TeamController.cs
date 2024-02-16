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
        public async Task<IActionResult> GetTeamsAsync()
        {
            try
            {
                var teams = await _teamService.GetAllTeams();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(Guid teamId)
        {
            try
            {
                await _teamService.Delete(teamId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditPost([FromBody] TeamDTO team)
        {
            try
            {
                await _teamService.UpdateTeam(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
