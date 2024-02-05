using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Models.DTOs;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Context _context;

        public DatabaseController(Context context)
        {
            _context = context;
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpGet("getTeams")]
        public async Task<IActionResult> GetTeams()
        {
            return Ok(await _context.Teams.ToListAsync());
        }

        [HttpPost("postTeams")]
        public async Task<IActionResult> Create(TeamDTO teamDto)
        {
            var newTeam = new Team
            {
                Id = Guid.NewGuid(),
                Name = teamDto.Name
            };

            await _context.AddAsync(newTeam);
            await _context.SaveChangesAsync();

            return Ok(newTeam);
        }

    }
}
