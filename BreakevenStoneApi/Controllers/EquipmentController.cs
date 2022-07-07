using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BreakevenStoneApi.Controllers
{
    public class EquipmentController : Controller
    {
        private EquipmentService _service { get; set; }

        public EquipmentController()
        {
            _service = new EquipmentService();
        }

        //Get : Equipment
        [HttpGet("equipmentByName")]
        public IActionResult EquipmentGetByName(string equipmentByN)
        {
            EquipmentDto equipmentByName = new EquipmentDto();
            equipmentByName.Name = equipmentByN;
            _service.EquipmentGetByName(equipmentByName);
            return Ok(equipmentByName);//ver sobre restful
        }

        // Post: Equipment
        [HttpPost("EquipmentCreate")]
        public IActionResult EquipmentCreate(EquipmentDto equipmentCreat)
        {
            _service.EquipmentAdd(equipmentCreat);
            return Created("", equipmentCreat);
        }

        [HttpDelete("delete")]
        public void DeleteEquipment(string name)
        {
            _service.Delete(name);
                
        }
    
    }
}
