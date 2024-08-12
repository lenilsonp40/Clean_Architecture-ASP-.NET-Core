using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_ECommerce.API.Utilities;
using Sistema_ECommerce.API.ViewModels;
using Sistema_ECommerce.Core.Exceptions;
using Sistema_ECommerce.Services.DTO;
using Sistema_ECommerce.Services.Interfaces;

namespace Sistema_ECommerce.API.Controllers
{
    
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientesService _clientesService;

        public ClienteController(IMapper mapper, IClientesService clientesService)
        {
            _mapper = mapper;
            _clientesService = clientesService;
        }

        [HttpPost]
        [Route("/api/v1/cliente/create")]
        public async Task<IActionResult> Create([FromBody] CreateClienteViewModel clienteViewModel)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClientesDTO>(clienteViewModel);

                var clienteCreated = await _clientesService.Create(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = clienteCreated
                });
                

            }
            catch (DomainException ex)
            {
               return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));               
            }
            catch (Exception)
            {

               return StatusCode(500, Responses.ApplicationErrorMessage());                
            }

        }

        [HttpPut]
        [Route("/api/v1/cliente/update")]
        public async Task<IActionResult> Update([FromBody] UpdateClientesViewModel clientesViewModel)
        {
            try
            {
                var clienteDTO = _mapper.Map<ClientesDTO>(clientesViewModel);

                var clienteUpdated = await _clientesService.Update(clienteDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = clienteUpdated
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpDelete]
        [Route("/api/v1/cliente/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _clientesService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = null
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/cliente/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var cliente = await _clientesService.Get(id);

                if (cliente == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado!",
                        Success = true,
                        Data = cliente
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = cliente
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/cliente/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allClientes = await _clientesService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allClientes
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/cliente/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var cliente = await _clientesService.GetByEmail(email);

                if (cliente == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado!",
                        Success = true,
                        Data = cliente
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = cliente
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/cliente/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allClientes = await _clientesService.SearchByName(name);

                if (allClientes.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o nome informado!",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allClientes
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpGet]
        [Route("/api/v1/cliente/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allClientes = await _clientesService.SearchByEmail(email);

                if (allClientes.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado!",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = allClientes
                });
            }

            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }
    }
}

