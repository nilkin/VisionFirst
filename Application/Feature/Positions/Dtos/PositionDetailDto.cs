using Application.Feature.Departments.Dtos;
using Domain.Dtos;

namespace Application.Feature.Positions.Dtos
{
    public class PositionDetailDto : IDto
    {
        public string? Title { get; set; }
        public int? DepartmentId { get; set; }
        public IList<DepartmentListDto> Departments { get; set; }
    }
}
