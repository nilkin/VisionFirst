using Application.Feature.LeaveApplications.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.LeaveApplications.Queries
{
    public class GetListLeaveApplicationQuery : IRequest<IList<LeaveApplicationListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListLeaveApplicationQuery, IList<LeaveApplicationListDto>>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
            }

            public async Task<IList<LeaveApplicationListDto>> Handle(GetListLeaveApplicationQuery request, CancellationToken cancellationToken)
            {
                IList<LeaveApplication>? LeaveApplication = await _LeaveApplicationRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.DateOfEntry), include: x => x.Include(x => x.Employee.Position.Department));
                var model = _mapper.Map<IList<LeaveApplicationListDto>>(LeaveApplication);
                return model;
            }
        }
    }
}
