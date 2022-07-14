using Flunt.Notifications;
using System;

namespace BreakevenStoneDomain.Entities
{
    public class Equipment : Notifiable<Notification>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateIn { get; private set; }
        public string Description { get; set; }
        public decimal? Price { get; private set; }

        public Equipment(string name, string description, decimal? price)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(name))
            {
                AddNotification("name", "Invalid name");
            }
            Name = name;
            DateIn = DateTime.Now;
            Description = description;
            Price = price;
        }
    }
}