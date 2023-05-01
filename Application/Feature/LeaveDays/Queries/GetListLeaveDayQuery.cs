using Application.Feature.LeaveDays.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.LeaveDays.Queries
{
    public class GetListLeaveDayQuery : IRequest<IList<LeaveDayListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListLeaveDayQuery, IList<LeaveDayListDto>>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveDayRepository _LeaveDayRepository;

            public Handler(IMapper mapper, ILeaveDayRepository LeaveDayRepository)
            {
                _mapper = mapper;
                _LeaveDayRepository = LeaveDayRepository;
            }

            public async Task<IList<LeaveDayListDto>> Handle(GetListLeaveDayQuery request, CancellationToken cancellationToken)
            {
                IList<LeaveDay>? LeaveDay = await _LeaveDayRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.EntryDate), include: x => x.Include(x => x.Position));
                var model = _mapper.Map<IList<LeaveDayListDto>>(LeaveDay);
                return model;
            }
        }
    }
}
