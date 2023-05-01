using Application.Feature.Employees.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Employees.Queries
{
    public class GetListEmployeeQuery : IRequest<IList<EmployeeListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListEmployeeQuery, IList<EmployeeListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public Handler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<IList<EmployeeListDto>> Handle(GetListEmployeeQuery request, CancellationToken cancellationToken)
            {
                IList<Employee>? Employee = await _employeeRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.DateOfEntry), include: x => x.Include(x => x.Position));
                var model = _mapper.Map<IList<EmployeeListDto>>(Employee);
                return model;
            }
        }
    }
}
