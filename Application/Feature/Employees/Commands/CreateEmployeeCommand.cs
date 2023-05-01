using Application.Feature.Employees.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public EmployeeAddDto? EmployeeAddDto;
        public sealed class Handler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public Handler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee mappedAdd = _mapper.Map<Employee>(request.EmployeeAddDto);
                Employee added = await _employeeRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }
}
