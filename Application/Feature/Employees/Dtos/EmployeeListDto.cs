using Domain.Dtos;
using Domain.Entities;

namespace Application.Feature.Employees.Dtos
{
    public class EmployeeListDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
