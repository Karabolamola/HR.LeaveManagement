using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveTypeRequest, LeaveTypeDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        
        public async Task<LeaveTypeDto> Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.DeleteAsync(request);
            return _mapper.Map<LeaveTypeDto>(leaveRequest);
        }
    }
}