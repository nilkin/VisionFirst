using Application.Feature.Accounts.Constants;
using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using Application.Tools;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feature.Accounts.Commands
{
    public class LoginAccountApiCommand : IRequest<AccountApiLoginDto>
    {
        public AccountLoginDto? AccountLoginDto;
        public sealed class Handler : IRequestHandler<LoginAccountApiCommand, AccountApiLoginDto>
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

            public async Task<AccountApiLoginDto> Handle(LoginAccountApiCommand request, CancellationToken cancellationToken)
            {

                Account? acc = await _accountRepository.GetAsync(predicate: x => x.Email == request.AccountLoginDto.Email);
                if (acc is not null)
                {
                    bool result = PasswordGeneratorExtension.VerifyPassword(request.AccountLoginDto.Password, acc.Password);
                    if (result)
                    {
                        AccountApiLoginDto logged = _mapper.Map<AccountApiLoginDto>(acc);
                        logged.Token = _tokenService.CreateToken(acc);
                        return logged;
                    }

                    else
                        return _mapper.Map<AccountApiLoginDto>(request.AccountLoginDto);
                }
                else
                    return _mapper.Map<AccountApiLoginDto>(request.AccountLoginDto);
            }
        }
    }
}
