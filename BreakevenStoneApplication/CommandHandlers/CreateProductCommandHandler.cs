using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response>
    {
        private ProductRepository _repository;

        public CreateProductCommandHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product productAdd = new Product(request.Status, request.Name, request.Price);
            if (productAdd.IsValid)
            {
                await _repository.Create(productAdd);
                return new Response("Success");
            }
            return new Response("Error");
        }
    }
}
