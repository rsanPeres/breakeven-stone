using Credit.NetCore.Framework.Cqrs.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class CreateUserCommand : Command<Unit>
    {
        public CreateUserCommand(string aggregateKey, string correlationKey, string applicationKey, string sagaProcessKey, string userEmail = null) : base(aggregateKey, correlationKey, applicationKey, sagaProcessKey, userEmail)
        {
        }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


    }
}
