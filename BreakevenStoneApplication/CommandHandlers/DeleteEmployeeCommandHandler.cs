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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Response>
    {
        private EmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.CPF);
            return new Response("Success");

        }
    }
}
