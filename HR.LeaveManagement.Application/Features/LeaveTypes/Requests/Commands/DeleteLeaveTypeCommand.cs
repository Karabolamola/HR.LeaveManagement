using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public sealed class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}