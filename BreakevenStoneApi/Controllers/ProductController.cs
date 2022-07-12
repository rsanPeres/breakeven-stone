using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private IMapper _mapper;
        private ProductService _service { get; set; }

        public ProductController(ProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("productByName")]
        public IActionResult ProductGetByName(GetProductRequest productByN)
        {
            try
            {
                var prod = _service.ProductGetByName(productByN.Name);
                var ret = _mapper.Map<GetProductResponse>(prod);
                var response = new ApiResponse<GetProductResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
            };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }
        }

        [HttpPost("productCreate")]
        public IActionResult ProductCreate(ProductRequest productCreate)
        {
            try
            {
                var dto = _mapper.Map<ProductDto>(productCreate);
                var prod = _service.ProductAdd(dto);
                var ret = _mapper.Map<GetProductResponse>(prod);
                var response = new ApiResponse<GetProductResponse>()
                {
                    Success = true,
                    Data = ret,
                    Messages = null
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new ApiResponse<string>()
                {
                    Success = false,
                    Data = null,
                    Messages = e.Message
                };
                return BadRequest(response);
            }

        }
    }
}
