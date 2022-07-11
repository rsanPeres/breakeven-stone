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

        public UserDto ClientGetByName(string name)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.UserFirstName == name.ToLower())
                       .FirstOrDefault<User>();
            if (userf != null) { 
                return _mapper.Map<UserDto>(userf);

            }
            return null;
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
            var user = new User(clientDto.Password, clientDto.FirstName.ToLower().Trim(), clientDto.FirstName.ToLower().Trim(), clientDto.CPF, clientDto.Birthday, clientDto.Address, clientDto.Email);
            if (user != null)
            {
            AppContext.Database.EnsureCreated();
            AppContext.User.Add(user);
            AppContext.SaveChanges();
                return _mapper.Map<UserDto>(user);
            }
            return null;
        }

        public UserDto ClientUpdate(UserDto userD)
        {
            var user = AppContext.User.Where(p => p.CPF == userD.CPF).ToList();
            if (user.Count > 0)
            {
                AppContext.User.Where(p => p.CPF == userD.CPF).ToList().ForEach(p => p.UserFirstName = userD.FirstName.ToLower());
            AppContext.SaveChanges();
                return _mapper.Map<UserDto>(user.First());
            }
            return null;
        }

        public UserDto ClientDelbyCpf(UserDto userD)
        {
            
            var userRemove = AppContext.User.First(p => p.CPF == userD.CPF);
            if (userRemove != null)
            {
            AppContext.User.Remove(userRemove);
            AppContext.SaveChanges();
                return _mapper.Map<UserDto>(userRemove);
            }
            return null;
        }
    }
}
