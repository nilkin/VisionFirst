using Application.Feature.Positions.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Positions.Commands
{
    public class UpdatePositionCommand : IRequest<PositionDetailDto>
    {
        public PositionDetailDto? PositionDetailDto;
        public sealed class Handler : IRequestHandler<UpdatePositionCommand, PositionDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IPositionRepository _positionRepository;

            public Handler(IMapper mapper, IPositionRepository positionRepository)
            {
                _mapper = mapper;
                _positionRepository = positionRepository;
            }

            public async Task<PositionDetailDto> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
            {
                Position? update = await _positionRepository.GetAsync(x => x.Id == request.PositionDetailDto.Id);
                Position? mapped = _mapper.Map(request.PositionDetailDto, update);
                Position? entity = await _positionRepository.UpdateAsync(mapped);
                PositionDetailDto result = _mapper.Map<PositionDetailDto>(mapped);
                return result;
            }
        }
    }
}
