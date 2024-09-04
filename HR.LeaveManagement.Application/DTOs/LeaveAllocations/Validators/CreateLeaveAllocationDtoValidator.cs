using FluentValidation;
using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            RuleFor(x => x.NumberOfDays).NotEmpty().WithMessage("{PropertyName} must not be empty.").NotNull().WithMessage("{PropertyName} must not be null.").GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.LeaveTypeId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await leaveAllocationRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");
            RuleFor(x => x.Period).NotEmpty().WithMessage("{PropertyName} must not be empty.").NotNull().WithMessage("{PropertyName} must not be null.").GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}