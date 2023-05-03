using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Accounts.Commands
{
    public class UpdateAccountCommand : IRequest<AccountDetailDto>
    {
        public AccountDetailDto? AccountDetailDto;
        public sealed class Handler : IRequestHandler<UpdateAccountCommand, AccountDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountDetailDto> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
            {
                Account? update = await _accountRepository.GetAsync(x => x.Id == request.AccountDetailDto.Id);
                Account? mapped = _mapper.Map(request.AccountDetailDto, update);
                Account? entity = await _accountRepository.UpdateAsync(mapped);
                AccountDetailDto result = _mapper.Map<AccountDetailDto>(mapped);
                return result;
            }
        }
    }
}
