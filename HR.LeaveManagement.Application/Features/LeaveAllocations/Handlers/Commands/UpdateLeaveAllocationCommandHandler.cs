using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(command.UpdateLeaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var leaveAllocation = await _leaveAllocationRepository.GetAsync(command.UpdateLeaveAllocationDto.Id);
            _mapper.Map(command.UpdateLeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            await _unitOfWork.SaveChangesToDatabaseAsync();
            return Unit.Value;
        }
    }
}