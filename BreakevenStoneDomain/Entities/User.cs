using System;

namespace BreakevenStoneDomain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CPF { get; set; }
        public DateTime Created { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public User() { }   
        public User(string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string address, string email)
        {
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

    }
}