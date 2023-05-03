using Application.Feature.LeaveApplications.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.LeaveApplications.Queries
{
    public class GetLeaveApplicationQuery : IRequest<LeaveApplicationDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetLeaveApplicationQuery, LeaveApplicationDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
            }

            public async Task<LeaveApplicationDetailDto> Handle(GetLeaveApplicationQuery request, CancellationToken cancellationToken)
            {
                LeaveApplication? LeaveApplication = await _LeaveApplicationRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Employee));
                var model = _mapper.Map<LeaveApplicationDetailDto>(LeaveApplication);
                return model;
            }
        }
    }
}
