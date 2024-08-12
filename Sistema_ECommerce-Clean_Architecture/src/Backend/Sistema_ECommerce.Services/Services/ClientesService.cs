using AutoMapper;
using Sistema_ECommerce.Core.Exceptions;
using Sistema_ECommerce.Domain.Entities;
using Sistema_ECommerce.Infra.Interfaces;
using Sistema_ECommerce.Services.DTO;
using Sistema_ECommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Services.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IMapper mapper, IClientesRepository clientesRepository)
        {
            _mapper = mapper;
            _clientesRepository = clientesRepository;
        }

        public async Task<ClientesDTO> Get(long Id)
        {
            var clientes = await _clientesRepository.GetAll();

            return _mapper.Map<ClientesDTO>(clientes);
        }

        public async Task<List<ClientesDTO>> GetAll()
        {
            var allClientes = await _clientesRepository.GetAll();

            return _mapper.Map<List<ClientesDTO>>(allClientes);
        }

        public async Task<ClientesDTO> Create(ClientesDTO clienteDTO)
        {
            var clientesExists = await _clientesRepository.GetByEmail(clienteDTO.Email);

            if (clientesExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado.");

            var clientes = _mapper.Map<Clientes>(clienteDTO);
            clientes.Validate();

            var clienteCreated = await _clientesRepository.Create(clientes);

            return _mapper.Map<ClientesDTO>(clienteCreated);
        }

        public async Task<ClientesDTO> Update(ClientesDTO clienteDTO)
        {
            var clientesExists = await _clientesRepository.Get(clienteDTO.Id);

            if (clientesExists != null)
                throw new DomainException("Não existe nenhum usuário com o id informado.");

            var clientes = _mapper.Map<Clientes>(clienteDTO);
            clientes.Validate();

            var clientesUpdated = await _clientesRepository.Update(clientes);

            return _mapper.Map<ClientesDTO>(clientesUpdated);
        }
        public async Task Remove(long Id)
        {
            await _clientesRepository.Remove(Id);
        }

        public async Task<ClientesDTO> GetByEmail(string email)
        {
            var clientes = await _clientesRepository.GetByEmail(email);

            return _mapper.Map<ClientesDTO>(clientes);
        }        

        public async Task<List<ClientesDTO>> SearchByEmail(string email)
        {
            var allClientes = await _clientesRepository.SearchByEmail(email);

            return _mapper.Map<List<ClientesDTO>>(allClientes);
        }

        public async Task<List<ClientesDTO>> SearchByName(string name)
        {
            var allClientes = await _clientesRepository.SearchByName(name);

            return _mapper.Map<List<ClientesDTO>>(allClientes);
        }

    }
}
