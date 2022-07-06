using System;

namespace BreakevenStoneDomain.Entities
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateIn { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public Equipment() { }

        public Equipment(string name, string description, decimal? price)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateIn = DateTime.Now;
            Description = description;
            Price = price;
        }
    }
}