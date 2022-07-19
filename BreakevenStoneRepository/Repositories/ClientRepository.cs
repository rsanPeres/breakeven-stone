using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using BreakevenStoneRepositoty.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneRepository.Repositories
{
    public class ClientRepository : IUserRepository
    {
        public ApplicationContext AppContext;

        public ClientRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public Task Create(User client)
        {
            AppContext.Database.EnsureCreated();
            AppContext.User.Add(client);
            AppContext.SaveChanges();
            return Task.CompletedTask;
        }

        public User Get(string cpf)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.CPF == cpf)
                       .FirstOrDefault<User>();
            return userf;
        }

        public Task Update(string address, string cpf)
        {
            var user = AppContext.User.First(p => p.CPF == cpf);
            if (user != null)
            {
                AppContext.User.Where(p => p.CPF == cpf).ToList().ForEach(p => p.Address = address);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }

        public Task Delete(string cpf)
        {
            var userRemove = AppContext.User.First(p => p.CPF == cpf);
            if (userRemove != null)
            {
                AppContext.User.Remove(userRemove);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }
    }
}
