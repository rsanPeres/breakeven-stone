using System;

namespace BreakevenStoneDomain.Entities
{
    public class Employee : User
    {
        public Guid EmployeeId { get; set; }
        public string Fuction { get; set; }
        public decimal Salary { get; set; }
        

        public Employee() { }
        public Employee(string fuction, decimal salary, string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string address)
        {
            EmployeeId = Guid.NewGuid();
            Fuction = fuction;
            Salary = salary;
            Id = Guid.NewGuid();
            Password = password;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            CPF = cPF;
            Created = DateTime.Now;
            Birthday = birthday;
            Address = address;
        }
    }
}