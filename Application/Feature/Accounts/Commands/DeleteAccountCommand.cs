using Application.Feature.Accounts.Constants;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Accounts.Commands
{
    public class DeleteAccountCommand : IRequest<string>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<DeleteAccountCommand, string>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<string> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
            {
                Account? delete = await _accountRepository.GetAsync(x => x.Id == request.Id);
                if (delete is not null)
                    await _accountRepository.DeleteAsync(delete);

                return AccountMessages.Deleted;
            }
        }
    }
}
