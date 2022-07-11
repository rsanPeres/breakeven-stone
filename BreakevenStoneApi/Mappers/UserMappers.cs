﻿using AutoMapper;
using BreakevenStoneApi.Controllers.Requests;
using BreakevenStoneApi.Controllers.Responses;
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
                .ForMember(p => p.UserFirstName, x => x.MapFrom(a => a.UserFirstName))
                .ForMember(p => p.UserLastName, x => x.MapFrom(a => a.UserLastName))
                .ReverseMap();

        }

        private void UserToDto()
        {
            CreateMap<User, UserDto>()
                .ForMember(p => p.UserFirstName, x => x.MapFrom(a => a.UserFirstName))
                .ForMember(p => p.UserLastName, x => x.MapFrom(a => a.UserLastName))
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

    }
}
