using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators;
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
    [Route("api/v1/equipment")]
    public class EquipmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private EquipmentService _service { get; set; }

        public EquipmentController(EquipmentService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult EquipmentGetByName(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new GetEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var equip = _service.EquipmentGetByName(request.Name);
                var ret = _mapper.Map<GetEquipmentResponse>(equip);
                var response = new ApiResponse<GetEquipmentResponse>()
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
        public async Task<IActionResult> EquipmentCreate(CreateEquipmentRequest request)
        {
            try
            {
                CreateEquipmentValidator validator = new CreateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<CreateEquipmentCommand>(request);
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

        [HttpPatch]
        public async Task<IActionResult> UpdateEquipment(UpdateEquipmentRequest request)
        {
            try
            {
                UpdateEquipmentValidator validator = new UpdateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<UpdateEquipmentCommand>(request);
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
        public async Task<IActionResult> DeleteEquipment(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new GetEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<DeleteEquipmentCommand>(request);
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
