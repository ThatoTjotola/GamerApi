using Gaming.Application.Dtos;
using Gaming.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController (IGameService _gameService): ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(GameDto gameDto)
        {
            await _gameService.AddGameAsync(gameDto);
            return CreatedAtAction(nameof(GetAllGames), gameDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto gameDto)
        {
            await _gameService.UpdateGameAsync(id, gameDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }
    }
}
