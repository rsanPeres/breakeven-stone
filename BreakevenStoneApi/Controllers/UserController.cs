using AutoMapper;
using BreakevenStoneApi.Controllers.Requests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet]
        public IActionResult UserGetByName(GetUserRequest userRequest)
        {
            try
            {
                var user = _service.ClientGetByName(userRequest.FirstName);
                var ret = _mapper.Map<GetUserResponse>(user);
                var response = new ApiResponse<GetUserResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult UserCreate(UserRequest userRequest)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(userRequest);
                var user = _service.ClientAdd(userDto);
                var ret = _mapper.Map<GetUserResponse>(user);
                var response = new ApiResponse<GetUserResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPatch]
        public IActionResult Update(UpdateUserRequest userRequest)
        {
            try {
                var userDto = _mapper.Map<UserDto>(userRequest);
                var user = _service.ClientUpdate(userDto);
                var ret = _mapper.Map<GetUserResponse>(user);
                var response = new ApiResponse<GetUserResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }



    [HttpDelete]
        public IActionResult Delete(UpdateUserRequest userRequest)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(userRequest);
                var user = _service.ClientDelbyCpf(userDto);
                var ret = _mapper.Map<GetUserResponse>(user);
                var response = new ApiResponse<GetUserResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }
    }
}
