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

        public EquipmentDto EquipmentAdd(EquipmentDto equipAdd)
        {
            Equipment equip = new Equipment(equipAdd.Name, equipAdd.Description, equipAdd.Price);
            if (equip != null)
            {
                AppContext.Database.EnsureCreated();
                AppContext.Equipment.Add(equip);
                AppContext.SaveChanges();
                return _mapper.Map<EquipmentDto>(equip);
            }
            return null;
        }

        public EquipmentDto EquipmentGetByName(string equip)
        {
            AppContext.Database.EnsureCreated();
            var equipf = AppContext.Equipment
                       .Where(pr => pr.Name == equip).FirstOrDefault<Equipment>();
            if(equipf != null) 
                return _mapper.Map<EquipmentDto>(equipf);
            
            return null;
            
        }

        public EquipmentDto EquipmentUpdate(string upName, string newName)
        {
            var up = AppContext.Equipment.Where(p => p.Name == upName).FirstOrDefault<Equipment>();
            if (up != null)
            {
                AppContext.Equipment.Where(p => p.Name == upName).ToList().ForEach(p => p.Name = newName);
                AppContext.SaveChanges();
                return _mapper.Map<EquipmentDto>(up);
            }
            return null;
            
        }

        public EquipmentDto Delete(string name)
        {
            var listRemove = AppContext.Equipment.Where(p => p.Name == name).FirstOrDefault<Equipment>();
            if (listRemove != null)
            {
                AppContext.Equipment.Remove(listRemove);
                AppContext.SaveChanges();
                return _mapper.Map<EquipmentDto>(listRemove);
            }
            return null;
        }
    }
}
