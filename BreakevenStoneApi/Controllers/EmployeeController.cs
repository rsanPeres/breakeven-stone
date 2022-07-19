using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using BreakevenStoneApi.Controllers.Requests.Validators.EmployeeValidators;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
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
        public async Task<IActionResult> EmployeeCreate(CreateEmployeeRequest employeeCreate)
        {
            try
            {
                CreateEmployeeValidator validator = new CreateEmployeeValidator();

                var result = validator.Validate(employeeCreate);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var request = _mapper.Map<CreateEmployeeCommand>(employeeCreate);
                var response = await _mediator.Send(request).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
        public async Task<IActionResult> Update(UpdateEmployeeRequest request)
        {
            try
            {
                UpdateEmployeeValidator validator = new UpdateEmployeeValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<UpdateEmployeeCommand>(request);
                var response = await _mediator.Send(reques).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
        public async Task<IActionResult> Delete(GetEmployeeRequest request)
        {
            try
            {
                GetEmployeeValidator validator = new GetEmployeeValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }
                var reques = _mapper.Map<DeleteEmployeeCommand>(request);
                var response = await _mediator.Send(reques).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
