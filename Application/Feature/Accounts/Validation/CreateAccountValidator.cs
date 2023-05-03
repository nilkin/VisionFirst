using Application.Feature.Accounts.Constants;
using Application.Feature.Accounts.Dtos;
using FluentValidation;

namespace Application.Feature.Accounts.Validation
{
    public class CreateAccountValidator : AbstractValidator<AccountAddDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(I => I.Email).NotNull().WithMessage(AccountMessages.NameNotBeNull);
            RuleFor(I => I.Email).EmailAddress().WithMessage(AccountMessages.EmailAdress);
            RuleFor(I => I.Password).NotNull().WithMessage(AccountMessages.PasswordNotBeNull);
            RuleFor(I => I.EmployeeId).NotNull().WithMessage(AccountMessages.EmployeeNotBeNull);
        }
    }
}
