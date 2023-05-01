using Application.Feature.LeaveDays.Constants;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.LeaveDays.Commands
{
    public class DeleteLeaveDayCommand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeleteLeaveDayCommand, string>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveDayRepository _leaveDayRepository;

            public Handler(IMapper mapper, ILeaveDayRepository leaveDayRepository)
            {
                _mapper = mapper;
                _leaveDayRepository = leaveDayRepository;
            }

            public async Task<string> Handle(DeleteLeaveDayCommand request, CancellationToken cancellationToken)
            {
                LeaveDay? delete = await _leaveDayRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _leaveDayRepository.DeleteAsync(delete);

                return LeaveDayMessages.Deleted;
            }
        }
    }
}
