using System;

namespace BreakevenStoneApi.Controllers.Requests
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
    }
}
