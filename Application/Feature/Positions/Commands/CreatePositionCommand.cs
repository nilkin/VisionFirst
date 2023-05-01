using Application.Feature.Positions.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Positions.Commands
{
    public class CreatePositionCommand : IRequest<int>
    {
        public PositionAddDto? PositionAddDto;
        public sealed class Handler : IRequestHandler<CreatePositionCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IPositionRepository _positionRepository;

            public Handler(IMapper mapper, IPositionRepository positionRepository)
            {
                _mapper = mapper;
                _positionRepository = positionRepository;
            }

            public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
            {
                Position mappedAdd = _mapper.Map<Position>(request.PositionAddDto);
                Position added = await _positionRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }
}
