using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneRepository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.CommandHandlers
{
    internal class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, Response>
    {
        private EquipmentRepository _repository;

        public CreateEquipmentCommandHandler(EquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            Equipment equip = new Equipment(request.Name, request.Description, request.Price);
            if (equip.IsValid)
            {
                await _repository.Create(equip); ;
                return new Response("Success");
            }
            return new Response("Error");
        }
    }
}
