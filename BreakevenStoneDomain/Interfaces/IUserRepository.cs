using BreakevenStoneDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakevenStoneDomain.Interfaces
{
    public interface IUserRepository
    {
        Task Save(User user);
    }
}
