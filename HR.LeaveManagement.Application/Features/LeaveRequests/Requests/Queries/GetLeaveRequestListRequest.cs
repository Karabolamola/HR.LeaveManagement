using System.Collections.Generic;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public sealed class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}