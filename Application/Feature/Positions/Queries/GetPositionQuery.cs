using Application.Feature.Positions.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Positions.Queries
{
    public class GetPositionQuery : IRequest<PositionDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetPositionQuery, PositionDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IPositionRepository _positionRepository;

            public Handler(IMapper mapper, IPositionRepository PositionRepository)
            {
                _mapper = mapper;
                _positionRepository = PositionRepository;
            }

            public async Task<PositionDetailDto> Handle(GetPositionQuery request, CancellationToken cancellationToken)
            {
                Position? position = await _positionRepository.GetAsync(x => x.Id==request.Id);
                var model = _mapper.Map<PositionDetailDto>(position);
                return model;
            }
        }
    }
}
