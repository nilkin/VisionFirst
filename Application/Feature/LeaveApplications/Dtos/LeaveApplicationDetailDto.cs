using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Feature.LeaveApplications.Dtos
{
    public class LeaveApplicationDetailDto : IDto
    {
        public LeaveStatus? Status { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public DateTime? LeaveStartTime { get; set; }
        public int? LeaveDuration { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
