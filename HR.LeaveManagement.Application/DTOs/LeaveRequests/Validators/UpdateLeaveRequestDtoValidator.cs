using FluentValidation;
using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}