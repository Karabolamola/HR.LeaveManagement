using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistance.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}