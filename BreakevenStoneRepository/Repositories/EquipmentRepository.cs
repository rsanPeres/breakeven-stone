using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using BreakevenStoneRepository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BreakevenStoneRepository.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public ApplicationContext AppContext;

        public EquipmentRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public Task Create(Equipment equip)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Equipment.Add(equip);
            AppContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Equipment Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var equipf = AppContext.Equipment
                       .Where(pr => pr.Name == name)
                       .FirstOrDefault<Equipment>();
            return equipf;
        }

        public Task Update(string name, string description)
        {
            var up = AppContext.Equipment.Where(p => p.Name == name).FirstOrDefault<Equipment>();
            if (up != null)
            {
                AppContext.Equipment.Where(p => p.Name == name).ToList().ForEach(p => p.Description = description);
                AppContext.SaveChanges();
                return Task.CompletedTask;
            }
            return null;
        }

        public Task Delete(string name)
        {
            var listRemove = AppContext.Equipment.Where(p => p.Name == name).FirstOrDefault<Equipment>();
            if (listRemove != null)
            {
                AppContext.Equipment.Remove(listRemove);
                AppContext.SaveChanges();
                AppContext.Database.EnsureDeleted();
                return Task.CompletedTask;
            }
            return null;
        }
    }
}
