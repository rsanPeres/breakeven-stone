using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class ProductMappers : Profile
    {
        public ProductMappers()
        {
            ProductRequestToDto();
            UpdateRequestToDto();
            DtoToGetResponse();
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

        private void DtoToGetResponse()
        {
            CreateMap<UserDto, GetProductResponse>()
                .ReverseMap();
        }
    }
}
