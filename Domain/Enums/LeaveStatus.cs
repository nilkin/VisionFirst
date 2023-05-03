using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum LeaveStatus : byte
    {
        [Display(Name = "Gəzləmədədir")]
        Pending = 1,
        [Display(Name = "Təsdiq edildi")]
        Approved,
        [Display(Name = "İmtina edildi")]
        Rejected
    }
}
