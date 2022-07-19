using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Commands
{
    public class UpdateEquipmentCommand : IRequest<Response>
    {
        public string Description { get; set; }
        public string NewDescription { get; set; }
    }
}
