using AutoMapper;
using Manager.API.ViewModels;
using Manager.Services.DTO;

namespace Manager.API.Utilities.DTOMappings
{
    public class UserDTOMappingProfile : Profile
    {
        public UserDTOMappingProfile()
        {
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            
        }
    }
}
