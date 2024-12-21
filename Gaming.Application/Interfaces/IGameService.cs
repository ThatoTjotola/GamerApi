using Gaming.Application.Dtos;
using Gaming.Domain.Entities;

namespace Gaming.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(GameDto gameDto);
        Task UpdateGameAsync(int id, GameDto gameDto);
        Task DeleteGameAsync(int id);
    }
}
