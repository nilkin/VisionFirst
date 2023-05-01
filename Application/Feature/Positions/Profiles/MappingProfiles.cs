using Application.Feature.Positions.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.Positions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Position, PositionAddDto>().ReverseMap();
            CreateMap<Position, PositionDetailDto>().ReverseMap();
            CreateMap<Position, PositionListDto>().ReverseMap();
        }
    }
}
