using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using BreakevenStoneApi.Controllers.Responses;
using BreakevenStoneDomain.Commands;
using BreakevenStoneDomain.Entities;
using BreakevenStoneDomain.Entities.Dtos;

namespace BreakevenStoneApi.Mappers
{
    public class EquipmentMappers : Profile
    {
        public EquipmentMappers()
        {
            EquipmentToDto();
            RequestToDto();
            DtoToResponse();
            CreatEquipmentToCreateEquipmentCommand();
            UpdateEquipmentToUpEquipmentCommand();
        }

        private void EquipmentToDto()
        {
            CreateMap<Equipment, EquipmentDto>()
                .ReverseMap();
        }

        private void RequestToDto()
        {
            CreateMap<CreateEquipmentRequest, EquipmentDto>()
                .ReverseMap();
        }

        private void DtoToResponse()
        {
            CreateMap<EquipmentDto, GetEquipmentResponse>()
                .ReverseMap();
        }

        private void CreatEquipmentToCreateEquipmentCommand()
        {
            CreateMap<CreateEquipmentRequest, CreateEquipmentCommand>()
                .ReverseMap();
        }

        private void UpdateEquipmentToUpEquipmentCommand()
        {
            CreateMap<UpdateEquipmentRequest, UpdateEquipmentCommand>()
                .ReverseMap();
        }

        private void DeleteEquipmentToDelEquipmentCommand()
        {
            CreateMap<GetEquipmentRequest, DeleteEquipmentCommand>()
                .ReverseMap();
        }
    }
}
