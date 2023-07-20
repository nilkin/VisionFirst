using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using Application.Tools;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Accounts.Commands
{
    public class CreateApiAccountCommand : IRequest<AccountRegisterDto>
    {
        public AccountApiRegisterDto? AccountApiRegisterDto;
        public sealed class Handler : IRequestHandler<CreateApiAccountCommand, AccountRegisterDto>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;
            private readonly ITokenService _tokenService;

            public Handler(IMapper mapper, IAccountRepository accountRepository, ITokenService tokenService)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
                _tokenService = tokenService;
            }

            public async Task<AccountRegisterDto> Handle(CreateApiAccountCommand request, CancellationToken cancellationToken)
            {
                Account mappedAdd = _mapper.Map<Account>(request.AccountApiRegisterDto);
                Account add = await _accountRepository.AddAsync(mappedAdd);
                AccountRegisterDto added = _mapper.Map<AccountRegisterDto>(add);
                added.Token = _tokenService.CreateToken(add);
                return added;
            }
        }
    }
}
