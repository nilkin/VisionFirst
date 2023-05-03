using Application.Feature.Employees.Dtos;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Feature.Accounts.Dtos
{
    public class AccountListDto : IDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? EmployeeId { get; set; }
        public Role? Role { get; set; }
        public Employee Employee { get; set; }
    }
}
