using Gaming.Domain.Entities;
using Gaming.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gaming.Infrastructure.Persistence
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync() => await _context.Games.ToListAsync();

        public async Task<Game> GetGameByIdAsync(int id) => await _context.Games.FindAsync(id);

        public async Task AddGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
