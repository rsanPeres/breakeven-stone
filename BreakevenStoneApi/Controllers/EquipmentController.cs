using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using BreakevenStoneApi.Controllers.Requests.Validators.EquipmentValidators;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/equipment")]
    public class EquipmentController : Controller
    {
        private readonly IMapper _mapper;
        private EquipmentService _service { get; set; }

        public EquipmentController(EquipmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
        public IActionResult EquipmentCreate(CreateEquipmentRequest request)
        {
            try {
                CreateEquipmentValidator validator = new CreateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var dto = _mapper.Map<EquipmentDto>(request);
                var equip = _service.EquipmentAdd(dto);
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

        [HttpPatch]
        public IActionResult UpdateEquipment(UpdateEquipmentRequest request)
        {
            try
            {
                UpdateEquipmentValidator validator = new UpdateEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var equip = _service.EquipmentUpdate(request.Name, request.NewName);
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

        [HttpDelete]
        public IActionResult DeleteEquipment(GetEquipmentRequest request)
        {
            try
            {
                GetEquipmentValidator validator = new GetEquipmentValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var equip = _service.Delete(request.Name);
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
    
    }
}
