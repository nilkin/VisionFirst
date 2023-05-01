using Application.Feature.LeaveDays.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.LeaveDays.Commands
{
    public class UpdateLeaveDayCommand : IRequest<LeaveDayDetailDto>
    {
        public LeaveDayDetailDto? LeaveDayDetailDto;
        public sealed class Handler : IRequestHandler<UpdateLeaveDayCommand, LeaveDayDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveDayRepository _leaveDayRepository;

            public Handler(IMapper mapper, ILeaveDayRepository leaveDayRepository)
            {
                _mapper = mapper;
                _leaveDayRepository = leaveDayRepository;
            }

            public async Task<LeaveDayDetailDto> Handle(UpdateLeaveDayCommand request, CancellationToken cancellationToken)
            {
                LeaveDay? update = await _leaveDayRepository.GetAsync(x => x.Id == request.LeaveDayDetailDto.Id);
                LeaveDay? mapped = _mapper.Map(request.LeaveDayDetailDto, update);
                LeaveDay? entity = await _leaveDayRepository.UpdateAsync(mapped);
                LeaveDayDetailDto result = _mapper.Map<LeaveDayDetailDto>(mapped);
                return result;
            }
        }
    }
}
