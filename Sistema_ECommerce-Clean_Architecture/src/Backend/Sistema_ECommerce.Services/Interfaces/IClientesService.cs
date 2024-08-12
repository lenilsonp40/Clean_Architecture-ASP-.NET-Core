using Sistema_ECommerce.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Services.Interfaces
{
    public interface IClientesService
    {
        Task<ClientesDTO> Create(ClientesDTO clienteDTO);
        Task<ClientesDTO> Update(ClientesDTO clienteDTO);
        Task Remove(long Id);
        Task<ClientesDTO> Get(long Id);
        Task<List<ClientesDTO>> GetAll();
        Task<List<ClientesDTO>> SearchByName(string name);
        Task<List<ClientesDTO>> SearchByEmail(string email);
        Task<ClientesDTO> GetByEmail(string email);
    }
}
