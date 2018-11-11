using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employees.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Employees.DataAccess.EntityFramework
{
    public class EmployeeRepository: Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesContext context)
            : base(context)
        {

        }

        public async Task<Employee> GetEmployeeByNameAsync(string firstName, string lastName)
        {
            return await EmployeeContext.Employees
                .Include(e => e.Jobs)
                .FirstOrDefaultAsync(e => e.FirstName.ToLower().Trim() == firstName.ToLower().Trim() &&
                                          e.LastName.ToLower().Trim() == lastName.ToLower().Trim());
        }

        public async Task<IEnumerable<Employee>> GetAllWithJobsAsync()
        {
            return await EmployeeContext.Employees
                .Include(e => e.Jobs)
                .ThenInclude(x => x.Job).ToListAsync();
        }

        private EmployeesContext EmployeeContext => this._context as EmployeesContext;
    }
}
