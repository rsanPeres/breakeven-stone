using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Linq;

namespace BreakevenStoneRepository.Repositories
{
    public class EmployeeRepository
    {
        ApplicationContext AppContext;

        public EmployeeRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public void Create(Employee employee)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Employee.Add(employee);
            AppContext.SaveChanges();
        }

        public Employee Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.Employee
                       .Where(us => us.UserFirstName == name.ToLower())
                       .FirstOrDefault<Employee>();
            return userf;
        }

        public Employee GetByCpf(string cpf)
        {
            AppContext.Database.EnsureCreated();
            var employeef = AppContext.Employee
                       .Where(em => em.CPF == cpf)
                       .FirstOrDefault<Employee>();
            return employeef;
        }

        public Employee Update(string cpf, string function)
        {
            var emplRet = AppContext.Employee.First(p => p.CPF == cpf);
            if (emplRet != null)
            {
                AppContext.Employee.Where(p => p.CPF == cpf).ToList().ForEach(p => p.Fuction = function);
                AppContext.SaveChanges();
                return emplRet;
            }
            return null;
        }

        public Employee Delete(string cpf)
        {
            var del = AppContext.Employee.First(p => p.CPF == cpf);
            if (del != null)
            {
                AppContext.Employee.Remove(del);
                AppContext.SaveChanges();
                return del;
            }
            return null;
        }
    }
}
