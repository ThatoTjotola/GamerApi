using Gaming.Domain.Entities;
using Gaming.Domain.Interfaces;
using System.Text.Json;

public class FileGameRepository : IGameRepository
{
    private readonly string _filePath = "games.json";

    public FileGameRepository()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]"); // Initialize empty JSON array if file doesn't exist
        }
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<Game>>(json) ?? new List<Game>();
    }

    public async Task<Game> GetGameByIdAsync(int id)
    {
        var games = await GetAllGamesAsync();
        return games.FirstOrDefault(g => g.Id == id);
    }

    public async Task AddGameAsync(Game game)
    {
        var games = (await GetAllGamesAsync()).ToList();
        game.Id = games.Any() ? games.Max(g => g.Id) + 1 : 1; // Auto-increment ID
        games.Add(game);
        await SaveToFileAsync(games);
    }

    public async Task UpdateGameAsync(Game game)
    {
        var games = (await GetAllGamesAsync()).ToList();
        var index = games.FindIndex(g => g.Id == game.Id);
        if (index != -1)
        {
            games[index] = game;
            await SaveToFileAsync(games);
        }
    }

    public async Task DeleteGameAsync(int id)
    {
        var games = (await GetAllGamesAsync()).Where(g => g.Id != id).ToList();
        await SaveToFileAsync(games);
    }

    private async Task SaveToFileAsync(List<Game> games)
    {
        var json = JsonSerializer.Serialize(games, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, json);
    }
}
