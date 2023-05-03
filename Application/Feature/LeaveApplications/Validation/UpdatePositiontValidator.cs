using Application.Feature.LeaveApplications.Constants;
using Application.Feature.LeaveApplications.Dtos;
using FluentValidation;

namespace Application.Feature.LeaveApplications.Validation
{
    public class UpdateLeaveApplicationValidator : AbstractValidator<LeaveApplicationDetailDto>
    {
        public UpdateLeaveApplicationValidator()
        {
            RuleFor(I => I.LeaveDuration).NotNull().WithMessage(LeaveApplicationMessages.LeaveDurationNotBeNull);
            RuleFor(x => x.LeaveDuration).GreaterThanOrEqualTo(1).WithMessage(LeaveApplicationMessages.NumberOfDaysGreaterThan)
           .NotEqual(-1).WithMessage(LeaveApplicationMessages.NumberOfDaysGreaterThan);
            RuleFor(I => I.LeaveStartTime).NotNull().WithMessage(LeaveApplicationMessages.LeaveStartTimeNotBeNull);
        }
    }
}
