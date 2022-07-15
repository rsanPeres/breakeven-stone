using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.UserRequests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            DtoToUser();
            UserToDto();
            DtoToRequest();
            RequestToUserDto();
            UpdateToUserDto();
            GetRequestToDto();
            UserToGetResponse();
            DeleteUserRequestToUserDto();
            GetUserRequestToCreateUserCommand();
        }

        private void RequestToUserDto()
        {
            CreateMap<UserDto, UserRequest>()
                .ReverseMap();
        }

       private void DtoToRequest()
        {
            CreateMap<UserRequest, UserDto>()
                .ReverseMap();
        }

        private void DtoToUser()
        {
            CreateMap<UserDto, User>()
                .ForMember(p => p.UserFirstName, x => x.MapFrom(a => a.FirstName))
                .ForMember(p => p.UserLastName, x => x.MapFrom(a => a.LastName))
                .ReverseMap();

        }

        private void UserToDto()
        {
            CreateMap<User, UserDto>()
                .ForMember(p => p.FirstName, x => x.MapFrom(a => a.UserFirstName))
                .ForMember(p => p.LastName, x => x.MapFrom(a => a.UserLastName))
                .ReverseMap();
        }

        private void UpdateToUserDto()
        {
            CreateMap<UpdateUserRequest, UserDto>()
                .ReverseMap();

        }

        private void GetRequestToDto()
        {
            CreateMap<GetUserRequest, UserDto>()
                .ReverseMap();
        }//GetUserRequest

        private void UserToGetResponse()
        {
            CreateMap<UserDto, GetUserResponse>()
                .ReverseMap();
        }

        private void DeleteUserRequestToUserDto()
        {
            CreateMap<DeleteUserRequest, UserDto>()
                .ReverseMap();
        }

        private void GetUserRequestToCreateUserCommand()
        {
            CreateMap<GetUserRequest, CreateUserCommand>()
                .ReverseMap();
        }
    }
}
