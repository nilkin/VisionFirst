using Application.Services.Source;
using Domain.Entities;
using Domain.Persistence;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class LeaveDayRepository : EfRepositoryBase<LeaveDay, BaseDbContext>, ILeaveDayRepository
    {
        public LeaveDayRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
