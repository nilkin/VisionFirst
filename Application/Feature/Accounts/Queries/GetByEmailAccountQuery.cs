using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Accounts.Queries
{
    public class GetByEmailAccountQuery : IRequest<AccountDetailDto>
    {
        public string Email { get; set; }
        public sealed class Handler : IRequestHandler<GetByEmailAccountQuery, AccountDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountDetailDto> Handle(GetByEmailAccountQuery request, CancellationToken cancellationToken)
            {
                Account? Account = await _accountRepository.GetAsync(x => x.Email == request.Email);
                var model = _mapper.Map<AccountDetailDto>(Account);
                return model;
            }
        }
    }
}
