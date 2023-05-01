using Application.Feature.LeaveDays.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.LeaveDays.Queries
{
    public class GetLeaveDayQuery : IRequest<LeaveDayDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetLeaveDayQuery, LeaveDayDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveDayRepository _leaveDayRepository;

            public Handler(IMapper mapper, ILeaveDayRepository leaveDayRepository)
            {
                _mapper = mapper;
                _leaveDayRepository = leaveDayRepository;
            }

            public async Task<LeaveDayDetailDto> Handle(GetLeaveDayQuery request, CancellationToken cancellationToken)
            {
                LeaveDay? LeaveDay = await _leaveDayRepository.GetAsync(x => x.Id == request.Id);
                var model = _mapper.Map<LeaveDayDetailDto>(LeaveDay);
                return model;
            }
        }
    }
}
