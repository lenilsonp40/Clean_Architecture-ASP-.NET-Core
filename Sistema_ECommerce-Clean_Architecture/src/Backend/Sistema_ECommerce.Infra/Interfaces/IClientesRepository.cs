using Sistema_ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Infra.Interfaces
{
    public interface IClientesRepository : IBaseRepository<Clientes>
    {
        Task<Clientes> GetByEmail(string email);
        Task<List<Clientes>> SearchByEmail(string email);
        Task<List<Clientes>> SearchByName(string name);
    }
}
