using AutoMapper;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Models;

namespace trailblazers_api.Mapper
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserCreationLoginDto>();
            CreateMap<UserCreationLoginDto, User>();
            CreateMap<UserAccessDto, User>();
            CreateMap<User, UserAccessDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserIdNameDto>();
        }
    }
}
