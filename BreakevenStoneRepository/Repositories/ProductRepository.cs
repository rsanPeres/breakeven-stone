using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Linq;

namespace BreakevenStoneRepository.Repositories
{
    public class ProductRepository
    {
        public ApplicationContext AppContext;

        public ProductRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public void Create(Product productAdd)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Product.Add(productAdd);
            AppContext.SaveChanges();
        }

        public Product GetByName(string name)
        {
            AppContext.Database.EnsureCreated();
            var prodf = AppContext.Product
                       .Where(pr => pr.Name == name)
                       .FirstOrDefault<Product>();
            if (prodf != null)
                return prodf;
            return null;
        }

        public Product Update(string name, string newDescription)
        {
            var prod = AppContext.Product.First(p => p.Name == name);
            if (prod != null)
            {
                AppContext.Product.Where(p => p.Name == name).ToList().ForEach(p => p.Status = newDescription);
                AppContext.SaveChanges();
                return prod;
            }
            return null;
        }

        public Product Delete(string name)
        {
            var product = AppContext.Product.Where(p => p.Name == name).FirstOrDefault();
            if (product != null)
            {
                AppContext.Product.Remove(product);
                AppContext.SaveChanges();
                return product;
            }
            return null;
        }
    }
}
