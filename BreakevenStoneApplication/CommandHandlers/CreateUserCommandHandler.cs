using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreakevenStoneDomain.Commands;
using BreakevenStoneApplication.Services;

namespace BreakevenStoneApplication.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private ClientService _service;
        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _service.ClientAdd(request);
            //chamar o eventbus
            return Unit.Task;
        }
    }
}
