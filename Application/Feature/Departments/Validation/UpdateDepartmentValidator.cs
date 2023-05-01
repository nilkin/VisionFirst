using Application.Feature.Departments.Constants;
using Application.Feature.Departments.Dtos;
using FluentValidation;

namespace Application.Feature.Departments.Validation
{
    public class UpdateDepartmentValidator : AbstractValidator<DepartmentDetailDto>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(I => I.ShortName).NotNull().WithMessage(DepartmentMessages.ShortNameNotBeNull);
            RuleFor(I => I.FullName).NotNull().WithMessage(DepartmentMessages.FullNameNotBeNull);
        }
    }
}
