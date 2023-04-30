using Application.Feature.Departments.Constants;
using Application.Feature.Departments.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Departments.Commands
{

    public class DeleteDepartmentComand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeleteDepartmentComand, string>
        {
            private readonly IMapper _mapper;
            private readonly IDepartmentRepository _departmentRepository;

            public Handler(IMapper mapper, IDepartmentRepository departmentRepository)
            {
                _mapper = mapper;
                _departmentRepository = departmentRepository;
            }

            public async Task<string> Handle(DeleteDepartmentComand request, CancellationToken cancellationToken)
            {
                Department? delete = await _departmentRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _departmentRepository.DeleteAsync(delete);

                return DepatmentMessages.Deleted;
            }
        }
    }

}
