using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Departments.Queries
{
    public class GetDepartmentQuery : IRequest<DepartmentDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetDepartmentQuery, DepartmentDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IDepartmentRepository _departmentRepository;

            public Handler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _mapper = mapper;
                _departmentRepository = departmentRepository;
            }

            public async Task<DepartmentDetailDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(predicate: x => x.Id == request.Id);
                var model = _mapper.Map<DepartmentDetailDto>(department);
                return model;
            }
        }
    }
}
