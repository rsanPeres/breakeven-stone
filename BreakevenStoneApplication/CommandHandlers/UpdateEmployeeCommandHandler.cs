using BreakevenStoneDomain.Commands;
using BreakevenStoneRepository.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.CommandHandlers
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Response>
    {
        private EmployeeRepository _repository;

        public UpdateEmployeeCommandHandler(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.CPF, request.Fuction);
            return new Response("Success");

        }
    }
}
