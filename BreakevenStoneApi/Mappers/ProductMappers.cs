using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.ProductRequests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
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
            ProductToDto();
            DtoToGetResponseReverse();
            ProductToDtoReverse();
            ProductRequestToCreateProductCommand();
            UpdateProductRequestToUpProductCommand();
            DeleteProductRequestToDelProductCommand();
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

        private void DtoToGetResponseReverse()
        {
            CreateMap<GetProductResponse, ProductDto>()
                .ReverseMap();
        }

        private void ProductToDto()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }

        private void ProductToDtoReverse()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }

        private void ProductRequestToCreateProductCommand()
        {
            CreateMap<ProductRequest, CreateProductCommand>()
                .ReverseMap();
        }

        private void UpdateProductRequestToUpProductCommand()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>()
                .ReverseMap();
        }

        private void DeleteProductRequestToDelProductCommand()
        {
            CreateMap<DeleteProductRequest, DeleteProductCommand>()
                .ReverseMap();
        }
    }
}
