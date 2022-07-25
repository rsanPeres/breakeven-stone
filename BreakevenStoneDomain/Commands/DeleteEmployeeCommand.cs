using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class DeleteEmployeeCommand : IRequest<Response>
    {
        public string FirstName { get; set; }
        public string CPF { get; set; }
    }
}
