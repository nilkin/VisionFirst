using Application.Feature.Accounts.Constants;
using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using Application.Tools;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Accounts.Commands
{
    public class LoginAccountCommand : IRequest<AccountDetailDto>
    {
        public AccountLoginDto? AccountLoginDto;
        public sealed class Handler : IRequestHandler<LoginAccountCommand, AccountDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountDetailDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
            {

                Account? acc = await _accountRepository.GetAsync(predicate: x => x.Email == request.AccountLoginDto.Email);
                if (acc is not null)
                {
                    bool result = PasswordGeneratorExtension.VerifyPassword(request.AccountLoginDto.Password, acc.Password);
                    if (result)
                    {
                        return _mapper.Map<AccountDetailDto>(acc);
                    }
                    else
                    {
                        return _mapper.Map<AccountDetailDto>(request.AccountLoginDto);
                    }
                }
                else
                {

                    return _mapper.Map<AccountDetailDto>(request.AccountLoginDto);
                }
            }
        }
    }
}
