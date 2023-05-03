using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using Application.Tools;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public AccountAddDto? AccountAddDto;
        public sealed class Handler : IRequestHandler<CreateAccountCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                Account mappedAdd = _mapper.Map<Account>(request.AccountAddDto);
                Account added = await _accountRepository.AddAsync(mappedAdd);
                return added.Id;
            }
        }
    }
}
