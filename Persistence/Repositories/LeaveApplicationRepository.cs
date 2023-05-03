using Application.Services.Source;
using Domain.Entities;
using Domain.Persistence;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class LeaveApplicationRepository : EfRepositoryBase<LeaveApplication, BaseDbContext>, ILeaveApplicationRepository
    {
        public LeaveApplicationRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
