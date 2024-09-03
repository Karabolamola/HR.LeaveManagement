using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public sealed class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}