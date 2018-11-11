using Employees.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeesContext _context;

        public UnitOfWork(EmployeesContext context)
        {
            _context = context;
            this.Employees = new EmployeeRepository(_context);
            this.Jobs = new Repository<Job>(_context);
        }

        public IEmployeeRepository Employees { get; private set; }

        public IRepository<Job> Jobs { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
