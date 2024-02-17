using Proiect.Models.DTOs;

namespace Proiect.Services.PlayerService
{
    public interface IPlayerService
    {
        Task<List<PlayerDTO>> GetAllPlayers();

        Task CreatePlayer(PlayerDTO player);

        Task Delete(Guid id);

        Task UpdatePlayer(PlayerDTO player);
    }
}
