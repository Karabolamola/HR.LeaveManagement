using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesToDatabaseAsync();
    }
}