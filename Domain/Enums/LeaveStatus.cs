using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum LeaveStatus : byte
    {
        [Display(Name = "Gözləmədədir")]
        Pending = 1,
        [Display(Name = "Təsdiq edildi")]
        Approved,
        [Display(Name = "İmtina edildi")]
        Rejected
    }
}
