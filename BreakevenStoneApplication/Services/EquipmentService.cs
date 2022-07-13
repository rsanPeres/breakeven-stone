using AutoMapper;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using BreakevenStoneRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakevenStoneApplication.Services
{
    public class EquipmentService
    {
        public EquipmentRepository _repository;
        private IMapper _mapper;
        public EquipmentService(IMapper mapper, EquipmentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public EquipmentDto EquipmentAdd(EquipmentDto equipAdd)
        {
            Equipment equip = new Equipment(equipAdd.Name, equipAdd.Description, equipAdd.Price);
            if (equip != null)
            {
                _repository.Create(equip);
                return _mapper.Map<EquipmentDto>(equip);
            }
            return null;
        }

        public EquipmentDto EquipmentGetByName(string equip)
        {
            var equipf = _repository.Get(equip);
            if (equipf != null)
                return _mapper.Map<EquipmentDto>(equipf);
            return null;

        }

        public EquipmentDto EquipmentUpdate(string upName, string newName)
        {
            var up = _repository.Update(upName, newName);
            if (up != null)
                return _mapper.Map<EquipmentDto>(up);
            return null;

        }

        public EquipmentDto Delete(string name)
        {
            var equip = _repository.Delete(name);
            if(equip != null)
            return _mapper.Map<EquipmentDto>(equip);
            return null;
        }
    }
}
