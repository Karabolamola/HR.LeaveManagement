using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateLeaveAllocationCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(command.CreateLeaveAllocationDto, cancellationToken);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(command.CreateLeaveAllocationDto);
            var leaveAllocationResponse = await _leaveAllocationRepository.AddAsync(leaveAllocation);
            return leaveAllocationResponse.Id;
        }
    }
}