using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationDtoValidator()
        {
            RuleFor(x => x.NumberOfDays).NotEmpty().WithMessage("{PropertyName} must not be empty.").NotNull().WithMessage("{PropertyName} must not be null.").GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.LeaveTypeId).NotEmpty().WithMessage("{PropertyName} must not be empty.").NotNull().WithMessage("{PropertyName} must not be null.").GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(x => x.Period).NotEmpty().WithMessage("{PropertyName} must not be empty.").NotNull().WithMessage("{PropertyName} must not be null.").GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}