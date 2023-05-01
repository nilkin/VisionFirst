using Application.Feature.Positions.Dtos;

namespace Application.Feature.Employees.Dtos
{
    public class EmployeeAddDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int? PositionId { get; set; }
        public IList<PositionListDto>? Positions { get; set; }
    }
}
