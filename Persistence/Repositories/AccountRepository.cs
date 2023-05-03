using Application.Services.Source;
using Domain.Entities;
using Domain.Persistence;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AccountRepository : EfRepositoryBase<Account, BaseDbContext>, IAccountRepository
    {
        public AccountRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
