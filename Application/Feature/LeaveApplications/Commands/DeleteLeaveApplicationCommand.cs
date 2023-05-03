using Application.Feature.LeaveApplications.Constants;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.LeaveApplications.Commands
{
    public class DeleteLeaveApplicationCommand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeleteLeaveApplicationCommand, string>
        {
            private readonly IMapper _mapper;
            private readonly ILeaveApplicationRepository _LeaveApplicationRepository;

            public Handler(IMapper mapper, ILeaveApplicationRepository LeaveApplicationRepository)
            {
                _mapper = mapper;
                _LeaveApplicationRepository = LeaveApplicationRepository;
            }

            public async Task<string> Handle(DeleteLeaveApplicationCommand request, CancellationToken cancellationToken)
            {
                LeaveApplication? delete = await _LeaveApplicationRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _LeaveApplicationRepository.DeleteAsync(delete);

                return LeaveApplicationMessages.Deleted;
            }
        }
    }
}
