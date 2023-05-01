using Application.Feature.Positions.Constants;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Positions.Commands
{
    public class DeletePositionComand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeletePositionComand, string>
        {
            private readonly IMapper _mapper;
            private readonly IPositionRepository _positionRepository;

            public Handler(IMapper mapper, IPositionRepository positionRepository)
            {
                _mapper = mapper;
                _positionRepository = positionRepository;
            }

            public async Task<string> Handle(DeletePositionComand request, CancellationToken cancellationToken)
            {
                Position? delete = await _positionRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _positionRepository.DeleteAsync(delete);

                return PositionMessages.Deleted;
            }
        }
    }
}
