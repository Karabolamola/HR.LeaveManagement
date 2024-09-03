using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommand : IRequestHandler<DeleteLeaveTypeCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommand(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(command.LeaveTypeDto);
            var leaveRequestResponse = await _leaveRequestRepository.DeleteAsync(leaveRequest);
            return leaveRequestResponse.Id;
        }
    }
}