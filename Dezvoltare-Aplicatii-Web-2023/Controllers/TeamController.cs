using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Services.TeamService;
using Proiect.Services.UserService;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("DeleteTeam")]
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

        [HttpPatch("UpdateTeam")]
        public async Task<IActionResult> EditTeam([FromBody] TeamDTO team)
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
        [HttpGet("filter-by-city")]
        public async Task<IActionResult> FilterTeamsByCity(string city)
        {
            try
            {
                var teamsInCity = _teamService.GetTeamsByCity(city);
              
                return Ok(teamsInCity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teams-with-players")]
        public async Task<IActionResult> GetTeamsWithPlayers()
        {
            try
            {
                var teamsWithPlayers =  _teamService.GetTeamsWithPlayers();
                   
                return Ok(teamsWithPlayers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
