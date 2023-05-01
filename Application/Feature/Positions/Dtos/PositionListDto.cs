using Domain.Dtos;
using Domain.Entities;

namespace Application.Feature.Positions.Dtos
{
    public class PositionListDto:IDto
    {
        public string Title { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
