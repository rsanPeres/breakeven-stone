using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneRepositoty.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        public User Get(string cpf);
        Task Update(string address, string cpf);
        Task Delete(string cpf);
    }
}
