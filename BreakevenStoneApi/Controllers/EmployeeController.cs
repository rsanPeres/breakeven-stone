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
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private EmployeeService _service { get; set; }
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    
        [HttpGet]
        public IActionResult EmployeeGetByName(GetEmployeeRequest employeeByN)
        {
            try
            {
                var user = _service.EmployeeGetByName(employeeByN.FirstName);
                
                var ret = _mapper.Map<GetEmployeeResponse>(user);
                var response = new ApiResponse<GetEmployeeResponse>()
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

        [HttpPost("employeeCreate")]
        public IActionResult EmployeeCreate(EmployeeDto employeeCreat)
        {
            try
            {
                var user = _service.EmployeeAdd(employeeCreat);
                var ret = _mapper.Map<GetEmployeeResponse>(user);
                var response = new ApiResponse<GetEmployeeResponse>()
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

        [HttpDelete("delete")]
        public IActionResult Delete(string name)
        {
            try
            {
                var user = _service.EmployeeDelbyCpf(name);
                var ret = _mapper.Map<GetEmployeeResponse>(user);
                var response = new ApiResponse<GetEmployeeResponse>()
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
