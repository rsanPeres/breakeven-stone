using AutoMapper;
using BreakevenStoneApi.Controllers.Requests;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private ClientService _service { get; set; }
        public UserController(ClientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Client
        [HttpGet("userByName")]
        public IActionResult UserGetByName(UpdateUserRequest userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var user = _service.ClientGetByName(userDto);
            if(user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult UserCreate(UserRequest userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var user = _service.ClientAdd(userDto);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPatch("update")]
        public IActionResult Update(UpdateUserRequest userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var users = _service.ClientUpdate(userDto);
            if(users != null)return Ok();
            return BadRequest(users);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(UpdateUserRequest userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            var user = _service.ClientDelbyCpf(userDto);
            if (user == null) return Ok();
            return BadRequest(user);

        }
    }
}
