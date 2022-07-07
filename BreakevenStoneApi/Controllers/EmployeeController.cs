using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BreakevenStoneApi.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _service { get; set; }

        public EmployeeController()
        {
            _service = new EmployeeService();
        }

        //Get : Employee
        [HttpGet("employeeByName")]
        public IActionResult EmployeeGetByName(string employeeByN)
        {
            EmployeeDto employeeByName = new EmployeeDto();
            employeeByName.FirstName = employeeByN;
            _service.EmployeeGetByName(employeeByName);
            return Ok(employeeByName);
        }

        // Post: Employee
        [HttpPost("login")]

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
