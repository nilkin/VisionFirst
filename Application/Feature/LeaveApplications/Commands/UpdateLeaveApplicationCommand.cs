﻿using Application.Feature.LeaveApplications.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.LeaveApplications.Commands
{
    public class UpdateLeaveApplicationCommand : IRequest<LeaveApplicationDetailDto>
    {
        public LeaveApplicationDetailDto? LeaveApplicationDetailDto;
        public sealed class Handler : IRequestHandler<UpdateLeaveApplicationCommand, LeaveApplicationDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
            }

            public async Task<LeaveApplicationDetailDto> Handle(UpdateLeaveApplicationCommand request, CancellationToken cancellationToken)
            {
                LeaveApplication? update = await _LeaveApplicationRepository.GetAsync(x => x.Id == request.LeaveApplicationDetailDto.Id,include:x=>x.Include(x=>x.Employee));
                Employee? employee = update?.Employee;
                LeaveApplication? mapped = _mapper.Map(request.LeaveApplicationDetailDto, update);
                mapped.Employee = employee;
                LeaveApplication? entity = await _LeaveApplicationRepository.UpdateAsync(mapped);
                LeaveApplicationDetailDto result = _mapper.Map<LeaveApplicationDetailDto>(mapped);
                return result;
            }
        }
    }
}
