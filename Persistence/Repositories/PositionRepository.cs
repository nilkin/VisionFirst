using Application.Services.Source;
using Domain.Entities;
using Domain.Persistence;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PositionRepository : EfRepositoryBase<Position, BaseDbContext>, IPositionRepository
    {
        public PositionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
