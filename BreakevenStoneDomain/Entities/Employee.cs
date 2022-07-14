using System;

namespace BreakevenStoneDomain.Entities
{
    public class Employee : User
    {
        public Employee(string function, decimal salary, string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string address, string email) : base(password, userFirstName, userLastName, cPF, birthday, address, email)
        {

            EmployeeId = Guid.NewGuid();
            if (string.IsNullOrEmpty(function))
                AddNotification("Function", "Invalid function");
            Fuction = function;
            Salary = salary;
            Id = Guid.NewGuid();
            Password = password;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            CPF = cPF;
            Created = DateTime.Now;
            Birthday = birthday;
            Address = address;
            Email = email;

        }

        public Guid EmployeeId { get; protected set; }
        public string Fuction { get; set; }
        public decimal Salary { get; protected set; }



    }
}