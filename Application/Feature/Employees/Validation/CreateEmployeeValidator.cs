using Application.Feature.Employees.Constants;
using Application.Feature.Employees.Dtos;
using FluentValidation;

namespace Application.Feature.Employees.Validation
{
    public class CreateEmployeeValidator : AbstractValidator<EmployeeAddDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage(EmployeeMessages.NameNotBeNull);
            RuleFor(I => I.Surname).NotNull().WithMessage(EmployeeMessages.SurnameNotBeNull);
            RuleFor(I => I.PositionId).NotNull().WithMessage(EmployeeMessages.PositionNotBeNull);
        }
    }
}
