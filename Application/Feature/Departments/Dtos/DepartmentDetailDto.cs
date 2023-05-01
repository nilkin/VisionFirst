using Domain.Dtos;

namespace Application.Feature.Departments.Dtos
{
    public class DepartmentDetailDto : IDto
    {
        public string? ShortName { get; set; }
        public string? FullName { get; set; }
        public string? Record { get; set; }
    }
}
