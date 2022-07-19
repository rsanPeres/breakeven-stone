using BreakevenStoneDomain.Entities;
using System.Threading.Tasks;

namespace BreakevenStoneRepositoty.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Create(Employee employee);
        public Employee Get(string cpf);
        Task Update(string cpf, string function);
        Task Delete(string cpf);
    }
}
