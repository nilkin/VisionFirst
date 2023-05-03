using Application.Feature.LeaveApplications.Constants;
using Application.Feature.LeaveApplications.Dtos;
using Application.Feature.LeaveDays.Constants;
using FluentValidation;

namespace Application.Feature.LeaveApplications.Validation
{
    public class CreateLeaveApplicationValidator : AbstractValidator<LeaveApplicationAddDto>
    {
        public CreateLeaveApplicationValidator()
        {
            RuleFor(I => I.LeaveDuration).NotNull().WithMessage(LeaveApplicationMessages.LeaveDurationNotBeNull);
            RuleFor(x => x.LeaveDuration).GreaterThanOrEqualTo(1).WithMessage(LeaveApplicationMessages.NumberOfDaysGreaterThan)
           .NotEqual(-1).WithMessage(LeaveApplicationMessages.NumberOfDaysGreaterThan);
            RuleFor(I => I.LeaveStartTime).NotNull().WithMessage(LeaveApplicationMessages.LeaveStartTimeNotBeNull);
        }
    }
}
