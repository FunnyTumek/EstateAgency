using AutoMapper;
using Contracts.DataTransferObject;
using Domain.Entities;

namespace Persistance.Configurations.MappingToDto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Estates, EstatesDto>();
            CreateMap<Estates, UpdateEstatesDto>();
            CreateMap<Estates, CreateEstatesDto>();
        }
    }
}
