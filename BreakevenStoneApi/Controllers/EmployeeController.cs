using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : Controller
    {
        private EmployeeService _service { get; set; }

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }
    

        [HttpGet("employeeByName")]
        public IActionResult EmployeeGetByName(string employeeByN)
        {
            EmployeeDto employeeByName = new EmployeeDto();
            employeeByName.FirstName = employeeByN;
            _service.EmployeeGetByName(employeeByName);
            return Ok(employeeByName);
        }

        [HttpPost("employeeCreate")]
        public IActionResult EmployeeCreate(EmployeeDto employeeCreat)
        {
            _service.EmployeeAdd(employeeCreat);
            return Created("", employeeCreat);
        }

        [HttpDelete("delete")]
        public void Delete(string name)
        {
            _service.EmployeeDelbyName(name);
        }

    }
}
