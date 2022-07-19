using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Commands;
using BreakevenStoneRepository.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private ClientRepository _repository;

        public UpdateUserCommandHandler(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Address, request.Cpf);
            return new Response("Success");
        }
    }
}
