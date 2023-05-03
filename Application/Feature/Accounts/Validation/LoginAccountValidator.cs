using Application.Feature.Accounts.Constants;
using Application.Feature.Accounts.Dtos;
using FluentValidation;

namespace Application.Feature.Accounts.Validation
{
    public class LoginAccountValidator : AbstractValidator<AccountLoginDto>
    {
        public LoginAccountValidator()
        {
            RuleFor(I => I.Email).NotNull().WithMessage(AccountMessages.NameNotBeNull);
            RuleFor(I => I.Email).EmailAddress().WithMessage(AccountMessages.EmailAdress);
            RuleFor(I => I.Password).NotNull().WithMessage(AccountMessages.PasswordNotBeNull);
        }
    }
}
