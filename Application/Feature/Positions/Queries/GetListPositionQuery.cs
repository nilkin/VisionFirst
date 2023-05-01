using Application.Feature.Positions.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Positions.Queries
{
    public class GetListPositionQuery : IRequest<IList<PositionListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListPositionQuery, IList<PositionListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IPositionRepository _positionRepository;

            public Handler(IMapper mapper, IPositionRepository PositionRepository)
            {
                _mapper = mapper;
                _positionRepository = PositionRepository;
            }

            public async Task<IList<PositionListDto>> Handle(GetListPositionQuery request, CancellationToken cancellationToken)
            {
                IList<Position>? position = await _positionRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.DateOfEntry),include:x=>x.Include(x=>x.Department));
                var model = _mapper.Map<IList<PositionListDto>>(position);
                return model;
            }
        }
    }
}
