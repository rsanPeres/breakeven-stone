using MediatR;
using System;

namespace BreakevenStoneDomain.Commands
{
    public class CreateEmployeeCommand : IRequest<Response>
    {
        public CreateEmployeeCommand(string fuction, decimal salary, string password, string firstName, string lastName, string cPF, DateTime birthday, string address, string email)
        {
            Fuction = fuction;
            Salary = salary;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Birthday = birthday;
            Address = address;
            Email = email;
        }

        public string Fuction { get; set; }
        public decimal Salary { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

}

