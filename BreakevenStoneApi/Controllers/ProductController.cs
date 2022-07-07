using BreakevenStoneApi.Controllers.Requests;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private ProductService _service { get; set; }

        public ProductController()
        {
            _service = new ProductService();
        }

        //Get : Product
        [HttpGet("productByName")]
        public IActionResult ProductGetByName(string productByN)
        {
            ProductDto productByName = new ProductDto
            {
                Name = productByN
            };
            _service.ProductGetByName(productByName);
            return Ok(productByName);//ver sobre restful
        }

        // Post: Product
        [HttpPost("productCreate")]
        public IActionResult ProductCreate(ProductDto productCreat)
        {
            _service.ProductAdd(productCreat);
            return Created("", productCreat);
        }

    }
}
