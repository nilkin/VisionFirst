using Application.Feature.LeaveApplications.Dtos;
using Application.Services.Reference.AccountServise;
using Application.Services.Source;
using Application.Tools;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Feature.LeaveApplications.Commands
{
    public class CreateLeaveApplicationCommand : IRequest<int>
    {
        public LeaveApplicationAddDto? LeaveApplicationAddDto;
        public sealed class Handler : IRequestHandler<CreateLeaveApplicationCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;
            private readonly IAccountServise _accountServise;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository, IAccountServise accountServise)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
                _accountServise = accountServise;
            }

            public async Task<int> Handle(CreateLeaveApplicationCommand request, CancellationToken cancellationToken)
            {

                Account? acc = await _accountServise.GetBySignInId(request.LeaveApplicationAddDto.SignInId);
                LeaveApplication mappedAdd = _mapper.Map<LeaveApplication>(request.LeaveApplicationAddDto);
                mappedAdd.EmployeeId = acc.EmployeeId;
                LeaveApplication added = await _LeaveApplicationRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }
}
