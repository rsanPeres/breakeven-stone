using System;

namespace BreakevenStoneApi.Controllers.Requests.ProductRequests
{
    public class ProductRequest
    //: ClientBoundRequest
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
    }
}
