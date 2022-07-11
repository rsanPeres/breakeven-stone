using System;

namespace BreakevenStoneApi.Controllers.Responses
{
    public class GetEmployeeResponse
    {
        public string Fuction { get; set; }
        public decimal Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
    }
}
