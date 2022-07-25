using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EmployeeRequests;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class EmployeeMappers : Profile
    {
        public EmployeeMappers()
        {
            RequestToDto();
            EmployeeToDto();
            DtoToResponse();
            CreateEmployeeRequestToDto();
            CreateEmployeeRequestToCreateEmployeeCommand();
            UpdateEmployeeRequestToUpEmployeeCommand();
        }

        private void RequestToDto()
        {
            CreateMap<GetEmployeeRequest, EmployeeDto>()
                .ReverseMap();
        }

        private void EmployeeToDto()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(p => p.FirstName, x => x.MapFrom(a => a.UserFirstName))
                .ForMember(p => p.LastName, x => x.MapFrom(a => a.UserLastName))
                .ReverseMap();
        }

        private void DtoToResponse()
        {
            CreateMap<EmployeeDto, GetEmployeeResponse>()
                .ReverseMap();
        }

        private void CreateEmployeeRequestToDto()
        {
            CreateMap<CreateEmployeeRequest, EmployeeDto>()
                .ReverseMap();
        }

        private void CreateEmployeeRequestToCreateEmployeeCommand()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>()
                .ReverseMap();
        }

        private void UpdateEmployeeRequestToUpEmployeeCommand()
        {
            CreateMap<UpdateEmployeeRequest, UpdateEmployeeCommand>()
                .ReverseMap();
        }

        private void GetEmployeeRequestToDeleteEmployeeCommand()
        {
            CreateMap<GetEmployeeRequest, DeleteEmployeeCommand>()
                .ReverseMap();
        }
    }
}
