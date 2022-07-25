using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string Cpf { get; set; }
    }
}
