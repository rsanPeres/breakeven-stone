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
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response>
    {
        private EmployeeRepository _repository;

        public CreateEmployeeCommandHandler(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee(request.Password, request.FirstName,
                request.LastName, request.CPF, request.Birthday, request.Address,
                request.Email, request.Fuction, request.Salary);
            if (employee.IsValid)
            {
                await _repository.Create(employee);
                return new Response("Success");
            }
            return new Response("Error");
        }
    }
}
