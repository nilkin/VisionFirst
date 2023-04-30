﻿using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.Departments.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, DepartmentAddDto>().ReverseMap();
            CreateMap<Department, DepartmentDetailDto>().ReverseMap();
            CreateMap<Department, DepartmentListDto>().ReverseMap();

        }
    }
}
