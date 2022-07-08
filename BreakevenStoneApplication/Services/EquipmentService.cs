using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneInfra;
using System.Collections.Generic;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class EquipmentService
    {
        public List<Equipment> Equipments { get; set; }
        public ApplicationContext AppContext { get; set; }
        private IMapper _mapper;
        public EquipmentService(IMapper mapper, ApplicationContext context)
        {
            AppContext = context;
            _mapper = mapper;
        }

        public void EquipmentAdd(EquipmentDto equipAdd)
        {
            Equipment equip = new Equipment(equipAdd.Name, equipAdd.Description, equipAdd.Price);
            AppContext.Database.EnsureCreated();
            AppContext.Equipment.Add(equip);
            AppContext.SaveChanges();
        }

        public List<Equipment> EquipmentGetByName(EquipmentDto equip)
        {
            AppContext.Database.EnsureCreated();
            var equipf = AppContext.Equipment
                       .Where(pr => pr.Name == equip.Name).ToList();
             return equipf;
            
        }

        public void EquipmentUpdate(string upName, string newName)
        {
            AppContext.Equipment.Where(p => p.Name == upName).ToList().ForEach(p => p.Name = newName);
            AppContext.SaveChanges();
        }

        public void Delete(string name)
        {
            var listRemove = AppContext.Equipment.Where(p => p.Name == name).ToList();
            foreach (var item in listRemove)
            {
                AppContext.Equipment.Remove(item);
                AppContext.SaveChanges();
            }
        }
    }
}
