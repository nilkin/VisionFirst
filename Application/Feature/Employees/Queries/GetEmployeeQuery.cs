using Application.Feature.Employees.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Employees.Queries
{
    public class GetEmployeeQuery : IRequest<EmployeeDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetEmployeeQuery, EmployeeDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _EmployeeRepository;

            public Handler(IMapper mapper, IEmployeeRepository EmployeeRepository)
            {
                _mapper = mapper;
                _EmployeeRepository = EmployeeRepository;
            }

            public async Task<EmployeeDetailDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                Employee? Employee = await _EmployeeRepository.GetAsync(x => x.Id == request.Id,x=>x.Include(x=>x.Position));
                var model = _mapper.Map<EmployeeDetailDto>(Employee);
                return model;
            }
        }
    }
}
