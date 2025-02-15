using Gaming.Application.Interfaces;
using Gaming.Application.Services;
using Gaming.Domain.Entities;
using Gaming.Domain.Interfaces;
using Gaming.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Listen on port 5000
});

builder.Services.AddControllers();

// Configure In-Memory Database
builder.Services.AddDbContext<GameContext>(options =>
    options.UseInMemoryDatabase("GameList"));

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GameContext>();
    SeedDatabase(dbContext);
}

app.Run();


void SeedDatabase(GameContext context)
{
    if (!context.Games.Any())
    {
        var games = new[]
        {
            new Game { Id = 1, Name = "Adventure Quest", Genre = "Adventure", Platform = "PC", ReleaseDate = new DateTime(2023, 5, 1), Price = 29.99m },
            new Game { Id = 2, Name = "Space Invaders", Genre = "Action", Platform = "Console", ReleaseDate = new DateTime(2024, 8, 15), Price = 49.99m },
            new Game { Id = 3, Name = "The last of us", Genre = "Horror", Platform = "Playstation", ReleaseDate = new DateTime(2024, 8, 15), Price = 149.99m }
        };

        context.Games.AddRange(games);
        context.SaveChanges();
    }
}
