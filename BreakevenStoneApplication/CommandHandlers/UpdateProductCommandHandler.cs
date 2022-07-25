using BreakevenStoneDomain.Commands;
using BreakevenStoneRepository.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.CommandHandlers
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response>
    {
        private ProductRepository _repository;

        public UpdateProductCommandHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(request.Name, request.Status);
            return new Response("Success");
        }
    }
}
