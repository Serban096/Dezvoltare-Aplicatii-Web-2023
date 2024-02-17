using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.Models.DTOs;
using Proiect.Services.PlayerService;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetPlayersAsync()
        {
            try
            {
                var players = await _playerService.GetAllPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreatePlayer")]
        public async Task<IActionResult> CreatePlayer(PlayerDTO player)
        {
            try
            {
                await _playerService.CreatePlayer(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(Guid playerId)
        {
            try
            {
                await _playerService.Delete(playerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditPlayer([FromBody] PlayerDTO player)
        {
            try
            {
                await _playerService.UpdatePlayer(player);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
