using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetAllLeaveRequestWithDetailsAsync();
        Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved);
    }
}