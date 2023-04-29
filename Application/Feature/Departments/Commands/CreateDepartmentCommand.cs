using Application.Feature.Departments.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Numerics;

namespace Application.Feature.Departments.Commands
{

    public class CreateDepartmentCommand : IRequest<int>
    {
        public DepartmentAddDto DepartmentAddDto { get; set; }
        public sealed class Handler : IRequestHandler<CreateDepartmentCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IDepartmentRepository _departmentRepository;

            public Handler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _mapper = mapper;
                _departmentRepository = departmentRepository;
            }

            public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department mappedAdd = _mapper.Map<Department>(request.DepartmentAddDto);
                Department added = await _departmentRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }

}
