using Application.Feature.LeaveDays.Constants;
using Application.Feature.LeaveDays.Dtos;
using FluentValidation;

namespace Application.Feature.LeaveDays.Validation
{
    public class UpdateLeaveDayValidator : AbstractValidator<LeaveDayDetailDto>
    {
        public UpdateLeaveDayValidator()
        {
            RuleFor(I => I.Note).NotNull().WithMessage(LeaveDayMessages.NoteNotBeNull);
            RuleFor(I => I.NumberOfDays).NotNull().WithMessage(LeaveDayMessages.NumberOfDaysNotBeNull);
            RuleFor(x => x.NumberOfDays).GreaterThanOrEqualTo(1).WithMessage(LeaveDayMessages.NumberOfDaysGreaterThan)
            .NotEqual(-1).WithMessage(LeaveDayMessages.NumberOfDaysGreaterThan);
            RuleFor(I => I.PositionId).NotNull().WithMessage(LeaveDayMessages.PositionNotBeNull);
        }
    }
}
