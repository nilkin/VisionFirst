using Domain.Entities;
using Domain.Persistence;

namespace Application.Services.Source
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
