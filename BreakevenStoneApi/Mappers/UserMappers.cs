using AutoMapper;
using BreakevenStoneApi.Controllers.Requests;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            UserDtoToUser();
            UserRequestToUserDto();
            UpdateToUserDto();
        }

        private void UserRequestToUserDto()
        {
            CreateMap<UserDto, UserRequest>()
                .ReverseMap();
        }

        private void UserDtoToUser()
        {
            CreateMap<UserDto, User>()
                .ForMember(p => p.UserFirstName, x => x.MapFrom(a => a.FirstName))
                .ForMember(p => p.UserLastName, x => x.MapFrom(a => a.LastName))
                .ReverseMap();

        }

        private void UpdateToUserDto()
        {
            CreateMap<UpdateUserRequest, UserDto>()
                .ReverseMap();

        }
    }
}
