using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Collections.Generic;
using System.Linq;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApplication.Services
{
    public class EmployeeService
    {
        public List<Employee> Employee { get; set; }
        public ApplicationContext AppContext { get; set; }

        public EmployeeService()
        {
            Employee = new List<Employee>();
            AppContext = new ApplicationContext();
        }

        public void EmployeeAdd(EmployeeDto employeeAdd)
        {
            Employee employee = new Employee(employeeAdd.Fuction, employeeAdd.Salary, employeeAdd.Password, employeeAdd.FirstName, employeeAdd.LastName, employeeAdd.CPF, employeeAdd.Birthday, employeeAdd.Address);
            AppContext.Database.EnsureCreated();
            AppContext.Employee.Add(employee);
            AppContext.SaveChanges();
        }

        public Employee EmployeeGetByName(EmployeeDto employeeFind)
        {
            AppContext.Database.EnsureCreated();
            var Employeef = AppContext.Employee
                       .Where(us => us.UserFirstName == employeeFind.FirstName)
                       .FirstOrDefault<Employee>();
            return Employeef;
        }

        public Employee EmployeeFindByCPF(EmployeeDto emplCPF)
        {
            AppContext.Database.EnsureCreated();
            var Employeef = AppContext.Employee
                       .Where(em => em.CPF == emplCPF.CPF)
                       .FirstOrDefault<Employee>();
            return Employeef;

        }

        public void EmployeeUpdate(string cpf, string name)
        {
            AppContext.User.Where(p => p.CPF == cpf).ToList().ForEach(p => p.UserFirstName = name);
            AppContext.SaveChanges();
        }

        public void EmployeeDelbyName(string EmployeeDel)
        {
            var listRemove = AppContext.Employee.Where(p => p.UserFirstName == EmployeeDel).ToList();
            foreach (var item in listRemove)
            {
                AppContext.Employee.Remove(item);
                AppContext.SaveChanges();
            }
        }
    }
}