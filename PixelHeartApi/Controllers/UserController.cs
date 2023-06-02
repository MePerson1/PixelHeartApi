using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixelHeartApi.Dto;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;
using PixelHeartApi.Repositories;

namespace PixelHeartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return BadRequest("Uzytkowik o takim id nie istnieje!");
            }
            return Ok(user);
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAll();
            if (users is null)
            {
                return BadRequest("Baza danych jest pusta!");
            }
            return Ok(users);
        }
        [HttpGet("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user is null)
            {
                return BadRequest("Uzytkowik o takim emailu nie istnieje!");
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var id = _userRepository.Create(user);
            return Created("/api/user/{id}", user);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var isSuccess = _userRepository.Update(id, user);
            if (!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id) 
        {
            var isSuccess = _userRepository.Delete(id);
            if (!isSuccess)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
