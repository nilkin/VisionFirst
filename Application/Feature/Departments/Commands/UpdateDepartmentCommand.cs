using Application.Feature.Departments.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Departments.Commands
{

    public class UpdateDepartmentCommand : IRequest<DepartmentDetailDto>
    {
        public DepartmentDetailDto? DepartmentDetailDto;
        public sealed class Handler : IRequestHandler<UpdateDepartmentCommand, DepartmentDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IDepartmentRepository _departmentRepository;

            public Handler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _mapper = mapper;
                _departmentRepository = departmentRepository;
            }

            public async Task<DepartmentDetailDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? update = await _departmentRepository.GetAsync(x=>x.Id==request.DepartmentDetailDto.Id);
                Department? mapped = _mapper.Map(request.DepartmentDetailDto, update);
                Department? entity = await _departmentRepository.UpdateAsync(mapped);
                DepartmentDetailDto  result = _mapper.Map<DepartmentDetailDto>(mapped);
                return result;
            }
        }
    }

}
