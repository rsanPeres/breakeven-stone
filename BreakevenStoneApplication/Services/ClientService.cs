using AutoMapper;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneRepository.Repositories;
using System;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.Services
{
    public class ClientService
    {
        private ClientRepository _repository;
        private IMapper _mapper;

        public ClientService(IMapper mapper, ClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task Create(CreateUserCommand clientDto)
        {
            var user = new User(clientDto.Password, clientDto.FirstName,
                clientDto.LastName, clientDto.Cpf,
                clientDto.Birthday, "rua camargos", clientDto.Email);
            if (user.IsValid)
            {
                _repository.Create(user);
                return Task.CompletedTask;
            }
            foreach (var notification in user.Notifications)
                Console.WriteLine($"{notification.Key} : {notification.Message}");
            return null;
        }

        public UserDto Get(UserDto cliCPF)
        {
            var userf = _repository.Get(cliCPF.CPF);
            if (userf != null) return _mapper.Map<UserDto>(userf);
            return null;
        }

        public Task Update(UserDto userD)
        {
            var user = _repository.Update(userD.Address, userD.CPF);
            if (user != null)
                return Task.CompletedTask;

            return null;
        }

        public Task Delete(UserDto userD)
        {
            var userRemove = _repository.Delete(userD.CPF);
            if (userRemove != null) return Task.CompletedTask;
            return null;
        }
    }
}
