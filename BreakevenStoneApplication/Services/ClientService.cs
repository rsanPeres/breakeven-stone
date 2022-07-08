using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using System.Collections.Generic;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class ClientService
    {
        private ApplicationContext AppContext { get; set; }
        private IMapper _mapper;

        public ClientService(IMapper mapper, ApplicationContext context)
        {
            AppContext = context;
            _mapper = mapper;
        }

        public UserDto ClientGetByName(UserDto dto)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.UserFirstName == dto.FirstName);
            if (userf == null)
            {
                return null;
            }
            UserDto user = new UserDto(); 
            _mapper.Map(user, userf);

            return user;
        }

        public UserDto ClientFindByCPF(UserDto cliCPF)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                            .FirstOrDefault(us => us.UserFirstName == cliCPF.CPF);

            if (userf == null) return null;
            return _mapper.Map<UserDto>(userf);
        }

        public UserDto ClientAdd(UserDto clientDto)
        {
            var user = new User(clientDto.Password, clientDto.FirstName, clientDto.LastName, clientDto.CPF, clientDto.Birthday, clientDto.Address);

            AppContext.Database.EnsureCreated();
            AppContext.User.Add(user);
            AppContext.SaveChanges();
            if (user != null) return _mapper.Map<UserDto>(user);
            return null;
        }

        public UserDto ClientUpdate(UserDto userD)
        {
            var user = AppContext.User.Where(p => p.CPF == userD.CPF).ToList();
            user.ForEach(p => p.UserFirstName = userD.FirstName);
            AppContext.SaveChanges();
            if (user.Count > 0) return _mapper.Map<UserDto>(user);
            return null;
        }

        public UserDto ClientDelbyCpf(UserDto userD)
        {
            
            var userRemove = AppContext.User.First(p => p.CPF == userD.CPF);
            AppContext.User.Remove(userRemove);
            AppContext.SaveChanges();

            if (userRemove != null) return _mapper.Map<UserDto>(userRemove);
            return null;
        }
    }
}
