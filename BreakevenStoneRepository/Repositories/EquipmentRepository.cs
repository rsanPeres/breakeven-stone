using BreakevenStoneDomain.Entities;
using BreakevenStoneInfra;
using System.Linq;

namespace BreakevenStoneRepository.Repositories
{
    public class EquipmentRepository
    {
        public ApplicationContext AppContext;

        public EquipmentRepository(ApplicationContext appContext)
        {
            AppContext = appContext;
        }

        public void Create(Equipment equip)
        {
            AppContext.Database.EnsureCreated();
            AppContext.Equipment.Add(equip);
            AppContext.SaveChanges();
        }

        public Equipment Get(string name)
        {
            AppContext.Database.EnsureCreated();
            var equipf = AppContext.Equipment
                       .Where(pr => pr.Name == name)
                       .FirstOrDefault<Equipment>();
            return equipf;
        }

        public Equipment Update(string name, string description)
        {
            var up = AppContext.Equipment.Where(p => p.Name == name).FirstOrDefault<Equipment>();
            if (up != null)
            {
                AppContext.Equipment.Where(p => p.Name == name).ToList().ForEach(p => p.Description = description);
                AppContext.SaveChanges();
                return up;
            }
            return null;
        }

        public Equipment Delete(string name)
        {
            var listRemove = AppContext.Equipment.Where(p => p.Name == name).FirstOrDefault<Equipment>();
            if (listRemove != null)
            {
                AppContext.Equipment.Remove(listRemove);
                AppContext.SaveChanges();
                AppContext.Database.EnsureDeleted();
                return listRemove;
            }
            return null;
        }
    }
}
