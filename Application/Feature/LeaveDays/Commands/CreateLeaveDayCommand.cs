using Application.Feature.LeaveDays.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.LeaveDays.Commands
{
    public class CreateLeaveDayCommand : IRequest<int>
    {
        public LeaveDayAddDto? LeaveDayAddDto;
        public sealed class Handler : IRequestHandler<CreateLeaveDayCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveDayRepository _leaveDayRepository;

            public Handler(IMapper mapper, ILeaveDayRepository leaveDayRepository)
            {
                _mapper = mapper;
                _leaveDayRepository = leaveDayRepository;
            }

            public async Task<int> Handle(CreateLeaveDayCommand request, CancellationToken cancellationToken)
            {
                LeaveDay mappedAdd = _mapper.Map<LeaveDay>(request.LeaveDayAddDto);
                LeaveDay added = await _leaveDayRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }
}
