using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Contract, ContractDTO>().ReverseMap();
            CreateMap<TimeLog, TimeLogDTO>().ReverseMap();
        }
    }
}
