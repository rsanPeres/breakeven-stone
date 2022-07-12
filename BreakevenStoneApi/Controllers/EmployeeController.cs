using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using BreakevenStoneApi.Controllers.Requests.Validators.EmployeeValidators;
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
        public IActionResult EmployeeGetByName(GetEmployeeRequest request)
        {
            try
            {
                GetEmployeeValidator validator = new GetEmployeeValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var user = _service.EmployeeFindByCPF(request.Cpf);

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

        [HttpPost]
        public IActionResult EmployeeCreate(CreateEmployeeRequest employeeCreate)
        {
            try
            {
                CreateEmployeeValidator validator = new CreateEmployeeValidator();

                var result = validator.Validate(employeeCreate);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var request = _mapper.Map<EmployeeDto>(employeeCreate);
                var user = _service.EmployeeAdd(request);
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

        [HttpPatch]
        public IActionResult Update(UpdateEmployeeRequest request)
        {
            try
            {
                UpdateEmployeeValidator validator = new UpdateEmployeeValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var user = _service.EmployeeUpdate(request.Cpf, request.Function);
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

        [HttpDelete]
        public IActionResult Delete(GetEmployeeRequest request)
        {
            try
            {
                GetEmployeeValidator validator = new GetEmployeeValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var user = _service.EmployeeDelbyCpf(request.Cpf);
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
