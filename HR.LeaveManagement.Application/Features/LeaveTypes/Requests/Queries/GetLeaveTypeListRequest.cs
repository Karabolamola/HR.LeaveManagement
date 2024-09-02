using System.Collections.Generic;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public sealed class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}