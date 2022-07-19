using BreakevenStoneDomain.Commands;
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
    internal class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand, Response>
    {
        private EquipmentRepository _repository;

        public UpdateEquipmentCommandHandler(EquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Description, request.NewDescription);
            return new Response("Success");
        }
    }
}
