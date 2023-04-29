using Domain.Enums;

namespace Domain.Entities
{
    public partial class LeaveApplication : Entity
    {
        public LeaveStatus Status { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime LeaveStartTime { get; set; }
        public int LeaveDuration { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
