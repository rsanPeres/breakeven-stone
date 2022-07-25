using BreakevenStoneDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneRepository.Interfaces
{
    public interface IEquipmentRepository
    {
        Task Create(Equipment equipment);
        public Equipment Get(string name);
        Task Update(string name, string status);
        Task Delete(string name);
    }
}
