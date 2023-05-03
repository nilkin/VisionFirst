namespace Application.Feature.LeaveApplications.Dtos
{
    public class LeaveApplicationAddDto
    {
        public DateTime? LeaveStartTime { get; set; }
        public int? LeaveDuration { get; set; }
        public int? SignInId { get; set; }
    }
}
