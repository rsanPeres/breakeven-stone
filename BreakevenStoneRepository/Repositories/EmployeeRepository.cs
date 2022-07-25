using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using BreakevenStoneRepositoty.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneRepository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationContext AppContext;

        public EmployeeRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public Task Create(Employee employee)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Employee.Add(employee);
            AppContext.SaveChanges();
            return Task.CompletedTask;
        }

        /*public Employee Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.Employee
                       .Where(us => us.UserFirstName == name.ToLower())
                       .FirstOrDefault<Employee>();
            return userf;
        }*/

        public Employee Get(string cpf)
        {
            AppContext.Database.EnsureCreated();
            var employeef = AppContext.Employee
                       .Where(em => em.CPF == cpf)
                       .FirstOrDefault<Employee>();
            return employeef;
        }

        public Task Update(string cpf, string function)
        {
            var emplRet = AppContext.Employee.First(p => p.CPF == cpf);
            if (emplRet != null)
            {
                AppContext.Employee.Where(p => p.CPF == cpf).ToList().ForEach(p => p.Function = function);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }

        public Task Delete(string cpf)
        {
            var del = AppContext.Employee.First(p => p.CPF == cpf);
            if (del != null)
            {
                AppContext.Employee.Remove(del);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }
    }
}
