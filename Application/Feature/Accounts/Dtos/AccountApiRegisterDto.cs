using Domain.Enums;

namespace Application.Feature.Accounts.Dtos
{
    public class AccountApiRegisterDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? EmployeeId { get; set; }
        public Role? Role { get; set; }
    }
}
