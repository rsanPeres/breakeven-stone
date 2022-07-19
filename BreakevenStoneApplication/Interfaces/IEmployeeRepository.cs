using BreakevenStoneDomain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneApplication.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Create();
        public EmployeeDto Get();
        Task Update();
        Task Delete();
    }
}
