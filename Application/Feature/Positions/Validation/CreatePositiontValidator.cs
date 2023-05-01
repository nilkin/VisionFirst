using Application.Feature.Positions.Constants;
using Application.Feature.Positions.Dtos;
using FluentValidation;

namespace Application.Feature.Positions.Validation
{
    public class CreatePositiontValidator : AbstractValidator<PositionAddDto>
    {
        public CreatePositiontValidator()
        {
            RuleFor(I => I.Title).NotNull().WithMessage(PositionMessages.TitleNotBeNull);
            RuleFor(I => I.DepartmentId).NotNull().WithMessage(PositionMessages.DepartmentNotBeNull);
        }
    }
}
