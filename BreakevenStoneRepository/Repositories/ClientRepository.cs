using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Linq;

namespace BreakevenStoneRepository.Repositories
{
    public class ClientRepository
    {
        public ApplicationContext AppContext;

        public ClientRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public void Create(User client)
        {
            AppContext.Database.EnsureCreated();
            AppContext.User.Add(client);
            AppContext.SaveChanges();
        }

        public User Get(string cpf)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.User
                       .Where(us => us.CPF == cpf)
                       .FirstOrDefault<User>();
            return userf;
        }

        public User Update(string name, string cpf)
        {
            var user = AppContext.User.First(p => p.CPF == cpf);
            if (user != null)
            {
                AppContext.User.Where(p => p.CPF == cpf).ToList().ForEach(p => p.UserFirstName = name);
                AppContext.SaveChanges();
                return user;
            }
            return null;
        }

        public User Delete(string cpf)
        {
            var userRemove = AppContext.User.First(p => p.CPF == cpf);
            if (userRemove != null)
            {
                AppContext.User.Remove(userRemove);
                AppContext.SaveChanges();
                return userRemove;
            }
            return null;
        }
    }
}
