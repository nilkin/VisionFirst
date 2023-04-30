using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Departments.Queries
{
    public class GetListDepartmentQuery : IRequest<IList<DepartmentListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListDepartmentQuery, IList<DepartmentListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IDepartmentRepository _departmentRepository;

            public Handler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _mapper = mapper;
                _departmentRepository = departmentRepository;
            }

            public async Task<IList<DepartmentListDto>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
            {
                IList<Department>? department = await _departmentRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.DateOfEntry));
                var model = _mapper.Map<IList<DepartmentListDto>>(department);
                return model;
            }
        }
    }
}
