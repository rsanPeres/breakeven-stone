﻿using System;

namespace BreakevenStoneApi.Controllers.Requests.UserRequests
{
    public class UserRequest
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}