using Application.Feature.Accounts.Dtos;
using Application.Tools;
using AutoMapper;
using Domain.Entities;

namespace Application.Feature.Accounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccountAddDto, Account>()
                .ForMember(t => t.Password, opt => opt.MapFrom(src => PasswordGeneratorExtension.HashPassword(src.Password, PasswordGeneratorExtension.GenerateSalt(16))));
            CreateMap<AccountDetailDto, Account>()
                .ForMember(t => t.Password, opt => opt.MapFrom(src => PasswordGeneratorExtension.HashPassword(src.NewPassword, PasswordGeneratorExtension.GenerateSalt(16))));
            CreateMap<Account, AccountDetailDto>()
                .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => string.Empty));
            CreateMap<Account, AccountListDto>().ReverseMap();
            CreateMap<Account, AccountLoginDto>().ReverseMap();
            CreateMap<Account, AccountApiLoginDto>().ReverseMap();
            CreateMap<Account, AccountRegisterDto>().ReverseMap();
            CreateMap<AccountDetailDto, AccountLoginDto>().ReverseMap();
        }
    }
}
