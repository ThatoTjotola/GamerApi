using Gaming.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gaming.Infrastructure.Persistence
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
    }
}
