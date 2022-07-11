using System;

namespace BreakevenStoneApi.Controllers.Requests.EmployeeRequests
{
    public class CreateEmployeeRequest
    {
        public string Fuction { get; set; }
        public decimal Salary { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
