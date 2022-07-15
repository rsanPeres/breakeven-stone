using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Interfaces
{
    public interface IUserRepository
    {
        Task Create(CreateUserCommand user);
        Task Get(UserDto user);
        Task Update(UserDto user);
        Task Delete(UserDto user);
    }
}
