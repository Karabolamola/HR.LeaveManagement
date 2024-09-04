using System;
using FluentValidation;
using HR.LeaveManagement.Application.Persistance.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            RuleFor(x => x.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");
            RuleFor(x => x.LeaveTypeId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                var leaveTypeExists = await leaveAllocationRepository.Exists(id);
                return !leaveTypeExists;
            }).WithMessage("{PropertyName} does not exist.");
            RuleFor(x => x.Period).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}.");
        }
    }
}