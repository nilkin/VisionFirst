using Application.Feature.Employees.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.Employees.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
        }
    }
}
