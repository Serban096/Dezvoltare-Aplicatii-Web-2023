using AutoMapper;
using Proiect.Models.DTOs;
using Proiect.Models;
using Proiect.Repositories.PlayerRepository;

namespace Proiect.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        public IPlayerRepository _playerRepository;
        public IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }


        public async Task<List<PlayerDTO>> GetAllPlayers()
        {
            var playerList = await _playerRepository.GetAllAsync();
            return _mapper.Map<List<PlayerDTO>>(playerList);
        }

        public async Task CreatePlayer(PlayerDTO player)
        {

            var newPlayer = new Player()
            {
                Id = Guid.NewGuid(),
                Name = player.Name,
                Age = player.Age,
                Position = player.Position,
                TeamId = player.teamId
            };

            await _playerRepository.CreateAsync(_mapper.Map<Player>(newPlayer));
            await _playerRepository.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var player = _playerRepository.FindById(id);
            if (player == null)
            {
                throw new Exception("Player doesnt exist");
            }
            _playerRepository.Delete(player);
            await _playerRepository.SaveAsync();
        }

        public async Task UpdatePlayer(PlayerDTO player)
        {
            var oldPlayer = _playerRepository.FindById(player.Id);
            if (oldPlayer == null)
            {
                throw new Exception("The player doesn't exist");
            }
            if (player.Name != null && player.Name != "")
                oldPlayer.Name = player.Name;

            _playerRepository.Update(_mapper.Map<Player>(oldPlayer));
            await _playerRepository.SaveAsync();
        }
    }
}
