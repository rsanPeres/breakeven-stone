using System;

namespace BreakevenStoneApi.Controllers.Requests.ProductRequests
{
    public class UpdateProductRequest
    {
        public DateTime DateOut { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
