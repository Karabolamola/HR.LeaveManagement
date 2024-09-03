using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public sealed class UpdateLeaveCommand : IRequest<Unit>
    {
        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
    }
}