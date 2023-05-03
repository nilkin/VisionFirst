using Application.Feature.LeaveApplications.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Services.Reference.AccountServise;

namespace Application.Feature.LeaveApplications.Queries
{
    public class GetListLeaveApplicationByEmployeeQuery : IRequest<IList<LeaveApplicationListDto>>
    {
        public int SignInId { get; set; }
        public sealed class Handler : IRequestHandler<GetListLeaveApplicationByEmployeeQuery, IList<LeaveApplicationListDto>>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;
            private readonly IAccountServise _accountServise;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository,IAccountServise accountServise)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
                _accountServise = accountServise;
            }

            public async Task<IList<LeaveApplicationListDto>> Handle(GetListLeaveApplicationByEmployeeQuery request, CancellationToken cancellationToken)
            {
                Account? account = await _accountServise.GetBySignInId(request.SignInId);
                IList<LeaveApplication>? LeaveApplication = await _LeaveApplicationRepository
                    .GetListAsync(orderBy: x => x.OrderByDescending(x => x.DateOfEntry), 
                    include: x => x.Include(x => x.Employee.Position.Department),predicate:x=>x.EmployeeId==account.EmployeeId);
                var model = _mapper.Map<IList<LeaveApplicationListDto>>(LeaveApplication);
                return model;
            }
        }
    }
}
