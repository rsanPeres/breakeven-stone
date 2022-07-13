using System;

namespace BreakevenStoneDomain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime DateIn { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOut { get; set; }
        public Product() { }

        public Product(string status, string name, decimal price)
        {
            Id = new Guid();
            DateIn = DateTime.Now;
            Status = status;
            Name = name;
            Price = price;
            DateOut = DateTime.Now;
        }
    }
}