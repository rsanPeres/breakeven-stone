using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
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

        [HttpGet("equipmentByName")]
        public IActionResult EquipmentGetByName(GetEquipmentRequest request)
        {
            try
            {
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

        [HttpPost("equipmentCreate")]
        public IActionResult EquipmentCreate(EquipmentDto equipmentCreat)
        {
            try { 
                var equip = _service.EquipmentAdd(equipmentCreat);
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

        [HttpDelete("delete")]
        public IActionResult DeleteEquipment(GetEquipmentRequest equipment)
        {
            try { 
                var equip = _service.Delete(equipment.Name);
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
