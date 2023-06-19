using Domain.Dtos;

namespace Application.Feature.Accounts.Dtos
{
    public class AccountRegisterDto : IDto
    {
        public string? Email { get; set; }
        public string Token { get; set; }

    }
}
