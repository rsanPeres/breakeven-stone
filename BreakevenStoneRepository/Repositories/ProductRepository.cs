using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using BreakevenStoneRepository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationContext AppContext;

        public ProductRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public Task Create(Product productAdd)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Product.Add(productAdd);
            AppContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Product Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var prodf = AppContext.Product
                       .Where(pr => pr.Name == name)
                       .FirstOrDefault<Product>();
            if (prodf != null)
                return prodf;
            return null;
        }

        public Task Update(string name, string newDescription)
        {
            var prod = AppContext.Product.First(p => p.Name == name);
            if (prod != null)
            {
                AppContext.Product.Where(p => p.Name == name).ToList().ForEach(p => p.Status = newDescription);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }

        public Task Delete(string name)
        {
            var product = AppContext.Product.Where(p => p.Name == name).FirstOrDefault();
            if (product != null)
            {
                AppContext.Product.Remove(product);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }
    }
}
