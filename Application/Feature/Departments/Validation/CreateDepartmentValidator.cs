using Application.Feature.Departments.Commands;
using Application.Feature.Departments.Constants;
using Application.Feature.Departments.Dtos;
using FluentValidation;

namespace Application.Feature.Departments.Validation
{
    public class CreateDepartmentValidator : AbstractValidator<DepartmentAddDto>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(I => I.ShortName).NotNull().WithMessage(DepartmentMessages.ShortNameNotBeNull);
            RuleFor(I => I.FullName).NotNull().WithMessage(DepartmentMessages.FullNameNotBeNull);
        }
    }
}
