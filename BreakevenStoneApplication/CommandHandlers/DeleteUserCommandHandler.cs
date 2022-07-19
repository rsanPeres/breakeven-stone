using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Commands;
using BreakevenStoneRepository.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response>
    {
        private ClientRepository _repository;

        public DeleteUserCommandHandler(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Cpf);
            return new Response("Success");
        }
    }
}

