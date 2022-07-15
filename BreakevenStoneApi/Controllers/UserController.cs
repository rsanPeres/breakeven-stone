﻿using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.UserRequests;
using BreakevenStoneApi.Controllers.Requests.Validators.UserValidators;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;
        private ClientService _service { get; set; }
        public UserController(ClientService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: Client
        [HttpGet]
        public IActionResult UserGetByName(GetUserRequest userRequest)
        {
            try
            {
                GetUserValidator validator = new GetUserValidator();

                var result = validator.Validate(userRequest);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }



                
                UserDto userDto = _mapper.Map<UserDto>(userRequest);
                var user = _service.ClientGetByCpf(userDto);
                
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
        public async Task<IActionResult> UserCreate(UserRequest userRequest)
        {
            try
            {
                CreateUserValidator validator = new CreateUserValidator();

                var result = validator.Validate(userRequest);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var request = _mapper.Map<CreateUserCommand>(userRequest);
                var response = await _mediator.Send(request).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);

                //var userDto = _mapper.Map<UserDto>(userRequest);
                //var user = _service.ClientAdd(userDto);
                /*var ret = _mapper.Map<GetUserResponse>(rett);

                var response = new ApiResponse<GetUserResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);*/
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
            try
            {
                UpdateUserValidator validator = new UpdateUserValidator();

                var result = validator.Validate(userRequest);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

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
        public IActionResult Delete(DeleteUserRequest userRequest)
        {
            try
            {
                DeleteUserValidator validator = new DeleteUserValidator();

                var result = validator.Validate(userRequest);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

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
