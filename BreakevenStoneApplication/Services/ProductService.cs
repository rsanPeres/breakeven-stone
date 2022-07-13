using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class ProductService
    {
        public List<Product> Products { get; set; }
        public ApplicationContext AppContext { get; set; }

        public IMapper _mapper;

        public ProductService(IMapper mapper, ApplicationContext context)
        {
            AppContext = context;
            _mapper = mapper;
        }

        public ProductDto ProductAdd(ProductDto prodAdd)
        {
            Product productAdd = new Product(prodAdd.Status, prodAdd.Name, prodAdd.Price);
            if (productAdd != null)
            {
                AppContext.Database.EnsureCreated();
                AppContext.Product.Add(productAdd);
                AppContext.SaveChanges();
                return _mapper.Map<ProductDto>(productAdd);
        }
            return null;
        }

        public ProductDto ProductGetByName(string prod)
        {
            AppContext.Database.EnsureCreated();
            var prodf = AppContext.Product
                       .Where(pr => pr.Name == prod).FirstOrDefault<Product>();
            if (prodf != null)
                return _mapper.Map<ProductDto>(prodf);
            return null;
        }

        public ProductDto ProductUpdate(string name, string newName, DateTime dateOut)
        {
            var prod = AppContext.Product.First(p => p.Name == name);
            if(prod != null)
        {
                AppContext.Product.Where(p => p.Name == name).ToList().ForEach(p => p.Name = newName);
                AppContext.SaveChanges();
                return _mapper.Map<ProductDto>(prod);
            }
            return null;
        }

        public ProductDto DelProductByName(string name)
        {
            var product = AppContext.Product.Where(p => p.Name == name).FirstOrDefault();
            if(product != null)
            {
                AppContext.Product.Remove(product);
                AppContext.SaveChanges();
                return _mapper.Map<ProductDto>(product);
            }
            return null;
        }
    }
}
