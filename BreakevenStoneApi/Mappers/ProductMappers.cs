using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers()
        {
            ProductRequestToDto();
            UpdateRequestToDto();
        }

        private void ProductRequestToDto()
        {
            CreateMap<ProductRequest, ProductDto>()
                .ReverseMap();
        }

        private void UpdateRequestToDto()
        {
            CreateMap<UpdateProductRequest, ProductDto>()
                .ReverseMap();
        }
    }
}
