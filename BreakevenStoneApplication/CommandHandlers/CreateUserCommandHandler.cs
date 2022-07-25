using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreakevenStoneDomain.Commands;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities;
using BreakevenStoneRepository.Repositories;

namespace BreakevenStoneApplication.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private ClientRepository _repository;

        public CreateUserCommandHandler(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Password, request.FirstName,
                request.LastName, request.Cpf,
                request.Birthday, "rua camargos", request.Email);
            if (user.IsValid)
            {
                await _repository.Create(user);
            }
            return Unit.Value;
        }
    }
}
