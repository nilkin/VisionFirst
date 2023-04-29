using Application.Services.Source;
using Domain.Entities;
using Domain.Persistence;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DepartmentRepository : EfRepositoryBase<Department, BaseDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
