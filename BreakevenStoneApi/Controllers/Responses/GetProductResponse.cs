using System;

namespace BreakevenStoneApi.Controllers.Responses
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public DateTime DateIn { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
