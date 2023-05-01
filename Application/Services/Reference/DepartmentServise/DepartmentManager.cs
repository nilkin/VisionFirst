using Application.Services.Source;

namespace Application.Services.Reference.DepartmentServise
{
    public class DepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
