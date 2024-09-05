using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}