using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using System.Collections.Generic;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class ProductService
    {
        public List<Product> Products { get; set; }
        public ApplicationContext AppContext { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
            AppContext = new ApplicationContext();
        }

        public void ProductAdd(ProductDto prodAdd)
        {
            Product productsAdd = new Product(prodAdd.Status, prodAdd.Name, prodAdd.Price, prodAdd.DateOut);
            Products.Add(productsAdd);
            AppContext.Database.EnsureCreated();
            AppContext.Product.Add(productsAdd);
            AppContext.SaveChanges();
        }

        public Product ProductGetByName(ProductDto prod)
        {
            AppContext.Database.EnsureCreated();
            var prodf = AppContext.Product
                       .Where(pr => pr.Name == prod.Name);
            return (Product)prodf;
        }

        public void ProductUpdate(string name, string newname)
        {
            AppContext.Product.Where(p => p.Name == name).ToList().ForEach(p => p.Name = newname);
            AppContext.SaveChanges();

        }
    }
}
