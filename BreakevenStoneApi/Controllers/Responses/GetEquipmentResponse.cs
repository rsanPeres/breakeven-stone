using System;

namespace BreakevenStoneApi.Controllers.Responses
{
    public class GetEquipmentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateIn { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
