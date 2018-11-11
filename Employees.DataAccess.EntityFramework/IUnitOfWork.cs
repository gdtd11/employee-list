using Employees.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DataAccess.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        IRepository<Job> Jobs { get; }

        Task<int> SaveAsync();
    }
}
