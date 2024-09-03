using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommand : IRequestHandler<UpdateLeaveCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommand(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(UpdateLeaveCommand command, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(command.LeaveRequestDto);
            var leaveRequestResponse = await _leaveRequestRepository.UpdateAsync(leaveRequest);
            return leaveRequestResponse.Id;
        }
    }
}