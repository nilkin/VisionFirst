using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Accounts.Queries
{
    public class GetAccountQuery : IRequest<AccountDetailDto>
    {
        public int Id { get; set; }
        public sealed class Handler : IRequestHandler<GetAccountQuery, AccountDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<AccountDetailDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
            {
                Account? Account = await _accountRepository.GetAsync(x => x.Id == request.Id);
                var model = _mapper.Map<AccountDetailDto>(Account);
                return model;
            }
        }
    }
}
