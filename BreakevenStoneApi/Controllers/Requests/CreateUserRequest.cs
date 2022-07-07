using System;

namespace BreakevenStoneApi.Controllers.Requests
{
    public class UserRequest 
        //: ClientBoundRequest
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

    }
}