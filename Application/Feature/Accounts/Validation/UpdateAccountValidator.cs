using Application.Feature.Accounts.Constants;
using Application.Feature.Accounts.Dtos;
using FluentValidation;

namespace Application.Feature.Accounts.Validation
{
    public class UpdateAccountValidator : AbstractValidator<AccountDetailDto>
    {
        public UpdateAccountValidator()
        {
            RuleFor(I => I.Email).NotNull().WithMessage(AccountMessages.NameNotBeNull);
            RuleFor(I => I.Email).EmailAddress().WithMessage(AccountMessages.EmailAdress);
            RuleFor(I => I.NewPassword).NotNull().WithMessage(AccountMessages.PasswordNotBeNull);
            RuleFor(I => I.EmployeeId).NotNull().WithMessage(AccountMessages.EmployeeNotBeNull);
        }
    }
}
