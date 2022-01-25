using AutoMapper;
using UserSystem.Models.Entities.Users;
using UserSystem.Shared.DTOs.Users;

namespace UserSystem.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
