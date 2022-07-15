using System;
using AutoMapper;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneRepository.Repositories;

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

        public UserDto ClientAdd(CreateUserCommand clientDto)
        {
            var user = new User(clientDto.Password, clientDto.FirstName.ToLower().Trim(), clientDto.FirstName.ToLower().Trim(), clientDto.CPF, clientDto.Birthday, string.Empty, clientDto.Email);
            if (user.IsValid)
                return _mapper.Map<UserDto>(user);

            foreach (var notification in user.Notifications)
                Console.WriteLine($"{notification.Key} : {notification.Message}");    
            return null;
        }

        public UserDto ClientGetByCpf(UserDto cliCPF)
        {
            var userf = _repository.Get(cliCPF.CPF);
            if (userf != null) return _mapper.Map<UserDto>(userf);
            return null;
        }

        public UserDto ClientUpdate(UserDto userD)
        {
            var user = _repository.Update(userD.Address, userD.CPF);
            if (user != null)
                return _mapper.Map<UserDto>(user);

            return null;
        }

        public UserDto ClientDelbyCpf(UserDto userD)
        {
            var userRemove = _repository.Delete(userD.CPF);
            if (userRemove != null) return _mapper.Map<UserDto>(userRemove);
            return null;
        }
    }
}
