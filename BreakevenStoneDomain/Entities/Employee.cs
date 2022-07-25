using System;

namespace BreakevenStoneDomain.Entities
{
    public class Employee : User
    {
        public Employee(string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string address, string email, string function, decimal salary) : base(password, userFirstName, userLastName, cPF, birthday, address, email)
        {
            if (string.IsNullOrEmpty(function))
                AddNotification("Function", "Invalid function");
            Function = function;
            Salary = salary;

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

        public string Function { get; set; }
        public decimal Salary { get; protected set; }



    }
}