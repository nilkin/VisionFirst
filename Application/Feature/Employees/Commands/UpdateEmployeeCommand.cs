using Application.Feature.Employees.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDetailDto>
    {
        public EmployeeDetailDto? EmployeeDetailDto;
        public sealed class Handler : IRequestHandler<UpdateEmployeeCommand, EmployeeDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _EmployeeRepository;

            public Handler(IMapper mapper, IEmployeeRepository EmployeeRepository)
            {
                _mapper = mapper;
                _EmployeeRepository = EmployeeRepository;
            }

            public async Task<EmployeeDetailDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee? update = await _EmployeeRepository.GetAsync(x => x.Id == request.EmployeeDetailDto.Id);
                Employee? mapped = _mapper.Map(request.EmployeeDetailDto, update);
                Employee? entity = await _EmployeeRepository.UpdateAsync(mapped);
                EmployeeDetailDto result = _mapper.Map<EmployeeDetailDto>(mapped);
                return result;
            }
        }
    }
}
