using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetAllLeaveRequestWithDetailsAsync();
        Task<LeaveRequest> GetLeaveRequestWithDetailsAsync(int id);
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved);
        Task<bool> Exists(int id);
    }
}