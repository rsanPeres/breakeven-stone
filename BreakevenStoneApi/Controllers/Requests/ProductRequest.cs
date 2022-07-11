using System;

namespace BreakevenStoneApi.Controllers.Requests
{
    public class ProductRequest 
        //: ClientBoundRequest
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOut { get; set; }
    }
}
