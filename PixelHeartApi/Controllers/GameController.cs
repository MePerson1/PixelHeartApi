using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GamesController : ControllerBase
        {
            public readonly IGameRepository _gameRepository;
            public readonly IMapper _mapper;
            public GamesController(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }
            [HttpGet]
            public IActionResult GetAllGames()
            {
                var games = _gameRepository.GetAll();
                return Ok(games);
            }
            [HttpGet("{id:int}")]
            public IActionResult GetGamesById(int id)
            {
                var game = _gameRepository.GetById(id);
                if (game is null)
                {
                    return NotFound();
                }
                return Ok(game);
            }
            [HttpPost]
            public IActionResult CreateGame([FromBody] Game gameCreate)
            {
                var id = _gameRepository.Create(gameCreate);
                return Created("/api/pizza/{id}", gameCreate);
            }
            [HttpPut("{id:int}")]
            public IActionResult UpdateGame([FromRoute] int id, [FromBody] Game game)
            {
                var isSuccess = _gameRepository.Update(id, game);
                if (!isSuccess)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpDelete("{id:int}")]
            public IActionResult DeleteGame(int id)
            {
                var isSuccess = _gameRepository.Delete(id);
                if (!isSuccess)
                {
                    return NotFound();
                }
                return NoContent();
            }
        }
    }
}
