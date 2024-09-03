using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveTypes.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.").NotNull().MinimumLength(1).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(x => x.DefaultDays).NotEmpty().WithMessage("{PropertyName} is required.").GreaterThan(0).WithMessage("{PropertyName} must be at least 1.").LessThan(100).WithMessage("{PropertyName} mst be less than 100.");
        }
    }
}