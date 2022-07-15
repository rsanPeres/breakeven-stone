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
        public string Password { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public string Email { get; protected set; }

        public CreateUserCommand(string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string email)
        {
            Password = password;
            FirstName = userFirstName;
            LastName = userLastName;
            CPF = cPF;
            Birthday = birthday;
            Email = email;
        }
    }
}
