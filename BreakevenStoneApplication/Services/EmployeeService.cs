namespace BreakevenStoneApplication.Services
{
    public class EmployeeService
    {
<<<<<<< Updated upstream
        
=======
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
            Employee employee = new Employee(employeeAdd.Fuction, employeeAdd.Salary, employeeAdd.Password, employeeAdd.FirstName, employeeAdd.LastName, employeeAdd.CPF, employeeAdd.Birthday, employeeAdd.Address);
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
            var user = _mapper.Map<EmployeeDto>(userf);

            return user;
        }

        public EmployeeDto EmployeeFindByCPF(EmployeeDto emplCPF)
        {
            AppContext.Database.EnsureCreated();
            var employeef = AppContext.Employee
                       .Where(em => em.CPF == emplCPF.CPF)
                       .FirstOrDefault<Employee>();
            if(employeef == null) return null;
            return _mapper.Map<EmployeeDto>(employeef);

        }

        public EmployeeDto EmployeeUpdate(string cpf, string name)
        {
            var emplRet = AppContext.Employee.Where(p => p.CPF == cpf).ToList();
            if(emplRet.Count() > 0)
            {
                AppContext.Employee.Where(p => p.CPF == cpf).ToList().ForEach(p => p.UserFirstName = name);
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
>>>>>>> Stashed changes
    }
}