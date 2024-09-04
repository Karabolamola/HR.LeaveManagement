using FluentValidation;
using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}.");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}.");
            RuleFor(x => x.LeaveTypeId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await leaveRequestRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");
        }
    }
}