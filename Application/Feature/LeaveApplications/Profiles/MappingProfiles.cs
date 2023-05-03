using Application.Feature.LeaveApplications.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.LeaveApplications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveApplication, LeaveApplicationAddDto>().ReverseMap();
            CreateMap<LeaveApplication, LeaveApplicationDetailDto>().ReverseMap();
            CreateMap<LeaveApplication, LeaveApplicationListDto>().ReverseMap();

        }
    }
}
