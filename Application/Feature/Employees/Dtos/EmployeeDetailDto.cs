using Application.Feature.Positions.Dtos;
using Domain.Dtos;

namespace Application.Feature.Employees.Dtos
{
    public class EmployeeDetailDto:IDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int? PositionId { get; set; }
        public IList<PositionListDto>? Positions { get; set; }
    }
}
