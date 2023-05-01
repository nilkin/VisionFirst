using Application.Feature.LeaveDays.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.LeaveDays.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveDay, LeaveDayAddDto>().ReverseMap();
            CreateMap<LeaveDay, LeaveDayDetailDto>().ReverseMap();
            CreateMap<LeaveDay, LeaveDayListDto>().ReverseMap();
        }
    }
}
