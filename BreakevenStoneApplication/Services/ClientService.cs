using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class ClientService
    {
        public ApplicationContext AppContext { get; set; }

        public ClientService()
        {
            AppContext = new ApplicationContext();
        }

        public User ClientGetByName(UserDto userFind)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.UserFirstName == userFind.FirstName)
                       .FirstOrDefault<User>();
            return userf;
        }

        public User ClientFindByCPF(UserDto cliCPF)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.UserFirstName == cliCPF.CPF)
                       .FirstOrDefault<User>();
            return userf;
        }

        public void ClientAdd(UserDto clientDto)
        {
            var user = new User(clientDto.Password, clientDto.FirstName, clientDto.LastName, clientDto.CPF, clientDto.Birthday, clientDto.Address);

            AppContext.Database.EnsureCreated();
            AppContext.User.Add(user);
            AppContext.SaveChanges();
        }

        public void ClientUpdate(string upCPF, string name)
        {
            AppContext.User.Where(p => p.CPF == upCPF).ToList().ForEach(p => p.UserFirstName = name);
            AppContext.SaveChanges();
        }

        public void ClientDelbyCpf(string cpf)
        {
            
            var listRemove = AppContext.User.Where(p => p.CPF == cpf).ToList();
            foreach(var item in listRemove)
            {
                AppContext.User.Remove(item);
                AppContext.SaveChanges();
            }

            
        }
    }
}
