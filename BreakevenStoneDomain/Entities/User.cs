using Flunt.Notifications;
using System;

namespace BreakevenStoneDomain.Entities
{
    public class User : Notifiable<Notification>
    {
        public User(string password, string userFirstName, string userLastName, string cPF, DateTime birthday, string address, string email)
        {

            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(password))
            {
                AddNotification("Password", "Invalid password");
            }
            Password = password;
            if (string.IsNullOrEmpty(userFirstName) && string.IsNullOrEmpty(userLastName))
            {
                AddNotification("name", "Invalid name");
            }
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            if (string.IsNullOrEmpty(cPF))
            {
                AddNotification("CPF", "Invalid CPF");
            }
            CPF = cPF;
            Created = DateTime.Now;
            Birthday = birthday;
            Address = address;
            if (string.IsNullOrEmpty(email))
            {
                AddNotification("Email", "Invalid email");
            }
            Email = email;
        }

        public Guid Id { get; protected set; }
        public string Password { get; protected set; }
        public string UserFirstName { get; protected set; }
        public string UserLastName { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime Created { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public string Address { get; set; }
        public string Email { get; protected set; }
    }
}