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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private ClientService _service;

        public CreateUserCommandHandler(ClientService service)
        {
            _service = service;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _service.Create(request);
            //chamar o eventbus
            return new Response("Success");
        }
    }
}
