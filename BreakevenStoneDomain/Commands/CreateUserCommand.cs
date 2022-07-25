using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public CreateUserCommand() { }

        public CreateUserCommand(string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string email)
        {
            Password = password;
            FirstName = userFirstName;
            LastName = userLastName;
            Cpf = cPF;
            Birthday = birthday;
            Email = email;
        }
    }
}
