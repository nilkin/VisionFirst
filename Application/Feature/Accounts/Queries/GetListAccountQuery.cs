using Application.Feature.Accounts.Dtos;
using Application.Services.Source;
using AutoMapper;
using MediatR;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Accounts.Queries
{
    public class GetListAccountQuery : IRequest<IList<AccountListDto>>
    {
        public sealed class Handler : IRequestHandler<GetListAccountQuery, IList<AccountListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAccountRepository _accountRepository;

            public Handler(IMapper mapper, IAccountRepository accountRepository)
            {
                _mapper = mapper;
                _accountRepository = accountRepository;
            }

            public async Task<IList<AccountListDto>> Handle(GetListAccountQuery request, CancellationToken cancellationToken)
            {
                IList<Account>? Account = await _accountRepository.GetListAsync(orderBy: x => x.OrderByDescending(x => x.Id), include: x => x.Include(x => x.Employee.Position.Department));
                var model = _mapper.Map<IList<AccountListDto>>(Account);
                return model;
            }
        }
    }
}
