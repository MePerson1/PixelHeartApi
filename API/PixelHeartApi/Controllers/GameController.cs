using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PixelHeartApi.Dto;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public readonly IGameRepository _gameRepository;
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public GamesController(IGameRepository gameRepository, IMapper mapper, IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<GameDto>>(games));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGamesById(int id)
        {
            var game = await _gameRepository.GetById(id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameDto gameCreate)
        {
            var game = _mapper.Map<Game>(gameCreate);

            var id = await _gameRepository.Create(game);

            //???
            return Created("/api/game/{id}", game);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int id, [FromBody] GameDto game)
        {
            var updatedGame = _mapper.Map<Game>(game);
            var isSuccess = await _gameRepository.Update(id, updatedGame);
            if (!isSuccess)
            {
                return NotFound();
            }
            return Ok("Game successfully updated!");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var isSuccess = await _gameRepository.Delete(id);
            if (!isSuccess)
            {
                return NotFound();
            }
            return Ok("Game successfully deleted!");
        }
        [HttpGet("{gameId:int}/user")]
        public async Task<IActionResult> GetUserByGameId(int gameId)
        {
            if (await _gameRepository.GetById(gameId) is null)
            {
                return BadRequest("Podana gra nie istnieje!");
            }
            var users = await _gameRepository.GetUserByGameId(gameId);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

    }
}
