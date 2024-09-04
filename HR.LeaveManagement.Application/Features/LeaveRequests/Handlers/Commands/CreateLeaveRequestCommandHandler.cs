using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequests.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreateLeaveRequestCommand requestCommand, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(requestCommand.CreateLeaveRequestDto, cancellationToken);
            if (validationResult.IsValid == false)
            {
                throw new Exception("The creation of the leave allocation is not valid.");
            }
            
            var leaveRequest = _mapper.Map<LeaveRequest>(requestCommand.CreateLeaveRequestDto);
            var leaveRequestResponse = await _leaveRequestRepository.AddAsync(leaveRequest);
            return leaveRequestResponse.Id;
        }
    }
}