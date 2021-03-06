using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneRepository.Repositories;

namespace BreakevenStoneApplication.Services
{
    public class ProductService
    {
        private ProductRepository _repository;

        private IMapper _mapper;

        public ProductService(IMapper mapper, ProductRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductDto ProductAdd(ProductDto prodAdd)
        {
            Product productAdd = new Product(prodAdd.Status, prodAdd.Name, prodAdd.Price);
            if (productAdd.IsValid)
            {
                _repository.Create(productAdd);
                return _mapper.Map<ProductDto>(productAdd);
            }
            return null;
        }

        public ProductDto ProductGetByName(string prod)
        {
            var prodf = _repository.Get(prod);
            if (prodf != null)
                return _mapper.Map<ProductDto>(prodf);
            return null;
        }

        public ProductDto ProductUpdate(string name, string newStatus)
        {
            var prod = _repository.Update(name, newStatus);
            if (prod != null)
                return _mapper.Map<ProductDto>(prod);
            return null;
        }

        public ProductDto DelProductByName(string name)
        {
            var ret = _repository.Delete(name);
            if (ret != null) return _mapper.Map<ProductDto>(ret);
            return null;
        }
    }
}
