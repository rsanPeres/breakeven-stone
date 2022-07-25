using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class DeleteEquipmentCommand : IRequest<Response>
    {
        public string Name { get; set; }
    }
}
