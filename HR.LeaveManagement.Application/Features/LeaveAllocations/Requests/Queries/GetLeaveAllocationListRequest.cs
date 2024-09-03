using System.Collections.Generic;
using HR.LeaveManagement.Application.DTOs.LeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public sealed class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}