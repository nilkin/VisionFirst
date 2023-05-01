using Application.Feature.Employees.Constants;
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
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeleteEmployeeCommand, string>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;

            public Handler(IMapper mapper, IEmployeeRepository employeeRepository)
            {
                _mapper = mapper;
                _employeeRepository = employeeRepository;
            }

            public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee? delete = await _employeeRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _employeeRepository.DeleteAsync(delete);

                return EmployeeMessages.Deleted;
            }
        }
    }
}
