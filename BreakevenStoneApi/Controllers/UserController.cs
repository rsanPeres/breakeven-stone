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
        //private readonly ICommandScheduler _commandScheduler;
        private ClientService _service { get; set; }
        public UserController()
        {
          //  _commandScheduler = commandScheduler;
            _service = new ClientService();
        }

        // GET: Client
        [HttpGet("userByName")]
        public IActionResult UserGetByName(string userByN)//criar o command e o handler
        {
            UserDto userByName = new UserDto();
            userByName.FirstName = userByN;
            _service.ClientGetByName(userByName);
            return Ok(userByName);
        }
        // Post: Client
        //[HttpPost("login")]
        //public IActionResult UserLogin(User userLogin)
        //{
        //    var test = userLogin.Id;
        //    return Created("", userLogin);
        //}

        [HttpPost("userCreate")]
        public IActionResult UserCreate(UserDto userCreat)
        {
            _service.ClientAdd(userCreat);
            return Created("", userCreat);

        }

        [HttpPost("userCreateWithCqrs")]
        public void UserCreateWithCqrs(UserRequest request)
        {
            /*var command = new CreateUserCommand(
                request,
                IdentityGenerator.NewSequentialIdentity(),
                request.RequestIdempotencyKey(),
                request.ApplicationKey(),
                request.SagaProccesKey()
                );
            _commandScheduler.RunNow(command);*/
        }

        [HttpPatch]
        public IActionResult Update(string cpf, string name)
        {
            _service.ClientUpdate(cpf, name);
            return Ok();
        }

        [HttpDelete]
        public void Delete(string cpf)
        {
            _service.ClientDelbyCpf(cpf);
        }
    }
}
