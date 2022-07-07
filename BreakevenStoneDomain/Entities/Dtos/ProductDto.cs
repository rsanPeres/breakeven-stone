using System;

namespace BreakevenStoneDomain.Entities.Dtos
{
    public class ProductDto
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOut { get; set; }
    }
}
