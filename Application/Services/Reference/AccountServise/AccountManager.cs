using Application.Services.Source;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Reference.AccountServise
{
    public class AccountManager: IAccountServise
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetBySignInId(int? signInId)
        {
            return await _accountRepository.GetAsync(x=>x.Id==signInId,include:x=>x.Include(x=>x.Employee));
        }
    }
}
