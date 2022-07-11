using System;

namespace BreakevenStoneApi.Controllers.Responses
{
    public class GetUserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
