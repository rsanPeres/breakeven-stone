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
    internal class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand, Response>
    {
        private EquipmentRepository _repository;

        public DeleteEquipmentCommandHandler(EquipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Name);
            return new Response("Success");
        }
    }
}
