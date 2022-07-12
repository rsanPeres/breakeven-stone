using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneApi.Controllers.Requests.Validators.ProductValidators;
using BreakevenStoneApi.Controllers.Requests.Validators.UserValidators;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Entities.Dtos;
using FluentValidation;
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

        [HttpGet]
        public IActionResult ProductGetByName(GetProductRequest productByN)
        {
            try
            {
                GetProductValidator validator = new GetProductValidator();

                var result = validator.Validate(productByN);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

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

        [HttpPost]
        public IActionResult ProductCreate(ProductRequest productCreate)
        {
            try
            {
                CreateProductValidator validator = new CreateProductValidator();

                var result = validator.Validate(productCreate);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

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

        [HttpPatch]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            try
            {
                UpdateProductValidator validator = new UpdateProductValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var prod = _service.ProductUpdate(request.Name, request.NewName, request.DateOut);
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

        [HttpDelete]
        public IActionResult DelelteProduct(DeleteProductRequest request)
        {
            try
            {
                DeleteProductValidator validator = new DeleteProductValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var prod = _service.DelProductByName(request.Name);
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
