using Domain.Dtos;
namespace Application.Feature.Departments.Dtos
{
    public class DepartmentListDto:IDto
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? Record { get; set; }
        public DateTime DateOfEntry { get; set; }
    }
}
