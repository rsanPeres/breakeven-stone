using Flunt.Notifications;
using System;

namespace BreakevenStoneDomain.Entities
{
    public class Product : Notifiable<Notification>
    {
        public Guid Id { get; private set; }
        public DateTime DateIn { get; private set; }
        public string Status { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; set; }
        public DateTime DateOut { get; private set; }

        public Product(string status, string name, decimal price)
        {
            Id = new Guid();
            DateIn = DateTime.Now;
            Status = status;
            if (string.IsNullOrEmpty(name))
            {
                AddNotification("name", "Invalid name");
            }
            Name = name;
            if (price < 0)
            {
                AddNotification("Price", "Invalid Price");
            }
            Price = price;
            DateOut = DateTime.Now;
        }
    }
}