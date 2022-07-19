using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneApi.Controllers.Requests.Validators.ProductValidators;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneApplication.Services;
using BreakevenStoneDomain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneApi.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private IMapper _mapper;
        private ProductService _service { get; set; }

        public ProductController(ProductService service, IMapper mapper, IMediator mediator)
        {
            _service = service;
            _mapper = mapper;
            _mediator = mediator;
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
        public async Task<IActionResult> ProductCreate(ProductRequest productCreate)
        {
            try
            {
                CreateProductValidator validator = new CreateProductValidator();

                var result = validator.Validate(productCreate);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<CreateProductCommand>(productCreate);
                var response = await _mediator.Send(reques).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            try
            {
                UpdateProductValidator validator = new UpdateProductValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<UpdateProductCommand>(request);
                var response = await _mediator.Send(reques).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
        public async Task<IActionResult> DelelteProduct(DeleteProductRequest request)
        {
            try
            {
                DeleteProductValidator validator = new DeleteProductValidator();

                var result = validator.Validate(request);
                if (result.IsValid == false)
                {
                    throw new Exception(result.ToString());
                }

                var reques = _mapper.Map<DeleteProductCommand>(request);
                var response = await _mediator.Send(reques).ConfigureAwait(false);

                return response.Errors.Any() ? BadRequest(response.Errors) : Ok(response.Result);
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
