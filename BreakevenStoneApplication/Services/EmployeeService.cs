using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Collections.Generic;
using System.Linq;
using BreakevenStoneDomain.Entities.Dtos;
using AutoMapper;

namespace BreakevenStoneApplication.Services
{
    public class EmployeeService
    {
        public List<Employee> Employee { get; set; }
        public ApplicationContext AppContext { get; set; }
        private IMapper _mapper;


        public EmployeeService(IMapper mapper, ApplicationContext context)
        {
            AppContext = context;
            _mapper = mapper;
        }

        public EmployeeDto EmployeeAdd(EmployeeDto employeeAdd)
        {
            Employee employee = new Employee(employeeAdd.Fuction, employeeAdd.Salary, 
                employeeAdd.Password, employeeAdd.FirstName, employeeAdd.LastName, 
                employeeAdd.CPF, employeeAdd.Birthday, employeeAdd.Address);
            if (employee != null) { 
                AppContext.Database.EnsureCreated();
                AppContext.Employee.Add(employee);
                AppContext.SaveChanges();
                return _mapper.Map<EmployeeDto>(employee);
            }
            return null;
        }

        public EmployeeDto EmployeeGetByName(string employeeFind)
        {
            AppContext.Database.EnsureCreated();
            var userf = AppContext.Employee
                       .Where(us => us.UserFirstName == employeeFind.ToLower())
                       .FirstOrDefault<Employee>();
            if (userf == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDto>(userf);

        }

        public EmployeeDto EmployeeFindByCPF(string emplCPF)
        {
            AppContext.Database.EnsureCreated();
            var employeef = AppContext.Employee
                       .Where(em => em.CPF == emplCPF)
                       .FirstOrDefault<Employee>();
            if(employeef == null) return null;
            return _mapper.Map<EmployeeDto>(employeef);

        }

        public EmployeeDto EmployeeUpdate(string cpf, string function)
        {
            var emplRet = AppContext.Employee.Where(p => p.CPF == cpf).ToList();
            if(emplRet.Count() > 0)
            {
                AppContext.Employee.Where(p => p.CPF == cpf).ToList().ForEach(p => p.Fuction = function);
                AppContext.SaveChanges();
                return _mapper.Map<EmployeeDto>(emplRet);
            }
            return null;
        }

        public EmployeeDto EmployeeDelbyCpf(string EmployeeDel)
        {
            var listRemove = AppContext.Employee.First(p => p.CPF == EmployeeDel);
            if(listRemove != null)
            {
                AppContext.Employee.Remove(listRemove);
                AppContext.SaveChanges();
                return _mapper.Map<EmployeeDto>(listRemove);
            }
            return null;
        }
    }
}