using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;

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

        [HttpGet("getPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _context.Players.ToListAsync());
        }

     
    }
}
