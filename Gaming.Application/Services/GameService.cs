using Gaming.Application.Dtos;
using Gaming.Application.Interfaces;
using Gaming.Domain.Entities;
using Gaming.Domain.Interfaces;


namespace Gaming.Application.Services
{
    public class GameService(IGameRepository _gameRepository) : IGameService
    {

        public async Task<IEnumerable<Game>> GetAllGamesAsync() => await _gameRepository.GetAllGamesAsync();

        public async Task<Game> GetGameByIdAsync(int id) => await _gameRepository.GetGameByIdAsync(id);

        public async Task AddGameAsync(GameDto gameDto)
        {
            //can probable use automapper here
            var game = new Game
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Platform = gameDto.Platform,
                ReleaseDate = gameDto.ReleaseDate,
                Price = gameDto.Price
            };
            await _gameRepository.AddGameAsync(game);
        }

        public async Task UpdateGameAsync(int id, GameDto gameDto)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            if (game == null) return;

            //also here
            game.Name = gameDto.Name;
            game.Genre = gameDto.Genre;
            game.Platform = gameDto.Platform;
            game.ReleaseDate = gameDto.ReleaseDate;
            game.Price = gameDto.Price;

            await _gameRepository.UpdateGameAsync(game);
        }

        public async Task DeleteGameAsync(int id) => await _gameRepository.DeleteGameAsync(id);
    }
}
