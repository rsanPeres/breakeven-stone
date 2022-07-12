using AutoMapper;
using BreakevenStoneApi.Controllers.Requests.EquipmentRequest;
using BreakevenStoneApi.Controllers.Responses;
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
    }
}
