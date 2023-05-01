using Application.Feature.Departments.Dtos;

namespace Application.Feature.Positions.Dtos
{
    public class PositionAddDto
    {
        public string? Title { get; set; }
        public int? DepartmentId { get; set; }
        public IList<DepartmentListDto> Departments { get; set; }
    }
}
