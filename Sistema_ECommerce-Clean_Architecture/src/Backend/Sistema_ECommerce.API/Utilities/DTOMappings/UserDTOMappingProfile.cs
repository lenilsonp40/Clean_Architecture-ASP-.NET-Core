using AutoMapper;
using Sistema_ECommerce.API.ViewModels;
using Sistema_ECommerce.Domain.Entities;
using Sistema_ECommerce.Services.DTO;

namespace Sistema_ECommerce.API.Utilities.DTOMappings
{
    public class UserDTOMappingProfile : Profile
    {
        public UserDTOMappingProfile()
        {
            CreateMap<CreateClienteViewModel, ClientesDTO>().ReverseMap();

            CreateMap<UpdateClientesViewModel, ClientesDTO>().ReverseMap();

            CreateMap<Clientes, ClientesDTO>().ReverseMap();

        }
    }
}
