using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeaveManagementDbContext _dbContext;

        public UnitOfWork(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesToDatabaseAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
