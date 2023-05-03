using Domain.Entities;

namespace Application.Services.Reference.AccountServise
{
    public interface IAccountServise
    {
        Task<Account> GetBySignInId(int? signInId);
    }
}
